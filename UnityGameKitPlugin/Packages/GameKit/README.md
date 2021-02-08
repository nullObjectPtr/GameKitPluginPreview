# Important!

This plugin is provided as a Unity Package Manager (UPM) package. It must be placed in the /packages directory for it to run correctly. It will NOT install correctly if you copy it into your assets folder. Please read the full setup instructions below to ensure proper installation.

# Hello
Thank you for downloading the HovelHouse Game Center Plugin
 
The plugin was written specifically with Apple Arcade in mind. It is a thin wrapper over the GameKit framework and made to work on MacOS, iOS and TVOS. It's aim is to be as close as possible to writing the equivalent in objective-c and makes very few assumptions and how you intend to use it. It simply marshals your data to the appropriate API calls.

The plugin targets iOS14 and macOS11 (BigSur). It is not compatible with earlier versions of iOS or MacOS. If you need to support earlier versions, you can grab the library project from the github repository and build targeting an earlier version. However, no direct support is provided for this. 

# Support
## Forums
Support is handled mainly via the forums: http://www.hovelhouse.com/forums but you are welcome to send an e-mail directly to us at support@hovelhouse.com

## Documentation
Setup and installation is covered in this document. For available API methods please refer to the apple documentation: https://developer.apple.com/documentation/gamekit?language=objc By and large, the method names and parameters will be the same. 
 
# Setup
 
 IMPORTANT: This plugin is provided as a Unity Package Manager (UPM) package. It must be placed in the /packages directory for it to run correctly. It will NOT install correctly if you copy it into your assets folder.
 
## Installing the Unity Package

* Unzip the archive and place the entire directory in the packages directory (this must be done from the finder)

OR

* Move the archive to a folder outside of your unity project and unzip it.
* Open "Window->Package Manager"
* Click the "+" button in the upper left and select "Add Package From Disk"
* Select the "package.json" file in the "GameKit" folder of inside the unzipped directory
* Unity will now import the package into your project
 
 There are three libraries provided. One dynamic library for MacOS, one static library for iOS, and one static library for TVOS.
 
 ## Samples
 The provided sample scene illustrates the basic usage of GameKit's core features: Authentication, Achievements, Leaderboards, the Access Point, Real Time and Turn Based matches. We recommend that you test your build with these scenes to ensure that you have everything set up correctly. Add SampleScene to your build scenes list to run them on device. 
 
Please note that the examples cannot be run in the editor editor. This is due to apples requirement that apps running Game Center be code-signed. 

Samples can be imported via the package manager in Unity 2019+.  2018 users should navigate to the Packages/com.hovelhouse.cloudkit/Samples~ folder on the filesystem (the folder is hidden in editor) and copy the directory into your assets director. Be sure to copy the meta files as well. 

## Usage
To use, import the namespace "HovelHouse.GameKit" and call GameKitInitialize() early on in your game's loading sequence. Before you can use any game-kit features you must first authenticate the current player. See the Sample_Authentication.cs for how to do this. 

## Building

### Required Build Settings - iOS

There are a few required build settings. Open "Player Settings -> Other Settings" and enter or set the following fields in the inspector:
Set *Target Minimum IOS Version" to  14. 32-bit "Universal Binary" builds are no longer supported by apple, and no 32bit library is provided. 
 
### Plugin Settings
 ** If you have your own post process build scripts, and this conflicts with that, you can disable this step by unchecking the "Enable Post Process Build" checkbox.
 
### MacOS
* You cannot target a MacOS version specifically in Unity. As mentioned previously, only the BigSur libraries are supplied with the plugin. You can still build your project from a Catalina mac, but any attempt to use the plugin will fail on Catalina. It will however, run correctly on a BigSur mac.
* If your project requires codesiging for macOS you are encouraged to read the MacOS codesigning guide at at http://www.hovelhouse.com/building_for_macos.html
 
# Known Issues
* VoiceChat is not yet supported
* There are several bugs with apple's game center API
** showing the game center dashboard, without having shown the access point, will result in a crash when the dashboard is closed
** macOS always reports that the Y position for the access point's "frameInScreenCoordinates" property is zero

# FAQ
* No questions yet. Be the first! Send an e-mail to support@hovelhouse.com
 
# Road Map
### P1
* VoiceChat support
* Better samples
