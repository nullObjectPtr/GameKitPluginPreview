using System.Collections;
using System.Collections.Generic;
using HovelHouse.GameKit;
using UnityEngine;

/// The Access Point is a new feature in GameKit that provides easy access to
/// the gamecenter UI from a widget on the screen
/// see https://developer.apple.com/documentation/gamekit/gkaccesspoint?language=objc
/// for all available API methods
public class Sample2_AccessPoint : AbstractSample
{
    public Sample2UI UI;
    
    void Awake()
    {
        OnAuthenticated();
    }
    
    protected override void OnAuthenticated()
    {
        // UI is non-interactable until we can authenticate
        UI.interactable = true;
        UI.OnToggleAccessPoint = OnToggleAccessPoint;
        UI.OnChangeAccessPointLocation = OnChangeAccessPointLocation;
        UI.OnShowDashboard = OnShowDashboard;

        StartCoroutine(PrintCoordsCo());
    }

    private IEnumerator PrintCoordsCo()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);
            if (GKAccessPoint.Shared.Active)
                UI.ScreenCoords = GKAccessPoint.Shared.FrameInScreenCoordinates;
        }
    }

    /// Triggered when the UI toggle is pressed
    private void OnToggleAccessPoint(bool showAccessPoint)
    {
        GKAccessPoint.Shared.Active = showAccessPoint;
    }

    // You can choose where this access point will show
    // Good luck designing your UI around it's placement!
    private void OnChangeAccessPointLocation(GKAccessPointLocation location)
    {
        GKAccessPoint.Shared.Location = location;
    }

    // You can jump directly to the gamecenter dashboard opened to a certain UI view programatticaly by passing the
    // enum value to "TriggerrAcessPointWithState".
    // All the possible access point views are listed in GKGameCenterViewControllerState
    // Opening leaderboards or achievements will require that you have set these up on App Store Connect
    // if you have not done so yet, the UI will open to a default page. 
    private void OnShowDashboard(GKGameCenterViewControllerState viewState)
    {
        GKAccessPoint.Shared.TriggerAccessPointWithState(viewState, OnAccessPointOpened);
    }

    /// <summary>
    /// This is a handler function for when the access point is presented
    /// </summary>
    private void OnAccessPointOpened()
    {
        Debug.Log("Access Point Is Showing");
    }
}
