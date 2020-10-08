#if UNITY_EDITOR
using System.IO;
using UnityEditor;
using UnityEditor.Callbacks;

#if UNITY_IOS || UNITY_TVOS || UNITY_STANDALONE_OSX
using Debug = UnityEngine.Debug;
using UnityEditor.Build;
using System.Linq;
using UnityEditor.iOS.Xcode;
#endif

namespace HovelHouse.CloudKit
{


    [InitializeOnLoad]
    public class BuildProcess
    {
        [PostProcessBuild(999)]
        public static void OnPostprocessBuild(BuildTarget target, string path)
        {
#if UNITY_IOS || UNITY_TVOS || UNITY_STANDALONE_OSX
            Debug.Log(string.Format("[HovelHouse.CloudKit] building for target: '{0}'", target));

            bool isXCodeTarget = false;

            if (target == BuildTarget.iOS || target == BuildTarget.tvOS)
            {
                isXCodeTarget = true;
            }
            else if (target == BuildTarget.StandaloneOSX)
            {
                // xcode for MacOS builds not supported before this version
#if UNITY_2019_3_OR_NEWER
                string setting = EditorUserBuildSettings.GetPlatformSettings("OSXUniversal", "CreateXcodeProject");
                bool.TryParse(setting, out isXCodeTarget);
#endif
            }

            if (isXCodeTarget)
            {
                PostProcessXCodeProject(path);
            }
#endif
        }

#if UNITY_IOS || UNITY_TVOS || UNITY_STANDALONE_OSX
        private const string ApplicationIdentifierEntitlement = "com.apple.application-identifier";
        
        private static void PostProcessXCodeProject(string path)
        {
            Debug.Log("Post Process X Code Project");
            Debug.Log("[HovelHouse.GameKit] " + path);

            // When building a MacOS xCode project, unity's GetPBXProjectPath
            // returns the wrong pbxproject path
#if UNITY_STANDALONE_OSX && UNITY_2019_3_OR_NEWER
            string pbxPath = Path.Combine(path, "./project.pbxproj");
#else
            var pbxPath = PBXProject.GetPBXProjectPath(path);
#endif
            var pbxProject = new PBXProject();
            pbxProject.ReadFromFile(pbxPath);

            var name = PlayerSettings.applicationIdentifier.Split('.').Last();


#if UNITY_2019_3_OR_NEWER

            // On MacOS GetUnityManTargetGuid returns null - so we have to look it up by name
            // but honestly, doesn't even look like the ProjectCapabilityManager is doing anything
            // on MacOS
#if UNITY_STANDALONE_OSX
            string targetGUID = pbxProject.TargetGuidByName(name);
            string entitlementsFilename = name + "/" + name + ".entitlements";
#else
            var targetGUID = pbxProject.GetUnityMainTargetGuid();
            var entitlementsFilename = name + ".entitlements";
#endif
            if (string.IsNullOrEmpty(targetGUID))
                throw new BuildFailedException("unable to find the GUID of the build target");

            ProjectCapabilityManager projCapability = new ProjectCapabilityManager(
                pbxPath, entitlementsFilename, null, targetGUID);
#else
            string entitlementsFilename = name + ".entitlements";
            ProjectCapabilityManager projCapability = new ProjectCapabilityManager(
                pbxPath, entitlementsFilename, PBXProject.GetUnityTargetName());
#endif

            projCapability.AddGameCenter();

            projCapability.WriteToFile();
        }
#endif
    }
}
#endif