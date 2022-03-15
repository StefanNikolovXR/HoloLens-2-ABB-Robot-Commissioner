# Azure Spatial Anchors Plugin for Unity

## Building in General
1. Navigate to `AzureSpatialAnchors.SDK/Resources`
2. Select **SpatialAnchorConfig**
3. Set `Spatial Anchors Account Id` to the value provided by the Azure portal.
4. Set `Spatial Anchors Account Key` to the value provided by the Azure portal.
5. When configuring scenes for the build, ensure that `AzureSpatialAnchorsDemoLauncher` is at index 0.

**NOTE:** The **SpatialAnchorConfig** file can be used in your own projects to share service credentials across scenes. When this file is used, you do not need to set these values on each **SpatialAnchorManager** in each scene. It's also possible to ignore this file in source control to avoid checking credentials into your repository.

## Building for Sharing
1. Navigate to `AzureSpatialAnchors.Examples/Resources`
2. Select **SpatialAnchorSamplesConfig**
3. Set `Base Sharing URL` to the address of your own instance of the sample sharing server.

**NOTE:** These values are currently only used by the `AzureSpatialAnchorsLocalSharedDemo` scene.

## Building for HoloLens

Build like a HoloLens project.

## Building for iOS

Nothing special when creating the Xcode project (compared to other ARKit projects)

After your first build:

1. From the exported project folder, run `pod install` to install the necessary CocoaPods.
2. Open `Unity-iPhone.xcworkspace` in Xcode.
3. Enable Automatic Signing in 'General' project settings (or whatever you need to do for signing).
4. Ensure deployment target is > 11.0.

## Building for Android

1. Export the project
    1. Open **Build Settings** by selecting **File > Build Settings...**.
    2. Select the **Export** button and select a location to export the Android project to.
    3. Open the project in Android Studio, build, and deploy.

## AAD user token scenario support for HoloLens

Instead of using an account key it's possible to acquire an AAD token and pass that into the SDK. For this we'll need to use the `Microsoft.IdentityModel.Clients.ActiveDirectory` library for the authentication.

1. Because there is no NuGet packaging system in Unity, you'll need to manually download the library and add the proper dll to your Assets folder. Steps for downloading nuget packages can be found [here](https://docs.microsoft.com/en-us/nuget/consume-packages/ways-to-install-a-package).

2. Once the package has been downloaded, copy the files from `Microsoft.IdentityModel.Clients.ActiveDirectory\4.5.0\lib\uap10.0` into your project under `Assets\Plugins\WSA`. Using the `Plugins\WSA` folder should automatically mark the library to only be used for Windows.

3. Next, open the file `AzureSpatialAnchors.SDK\Scripts\SpatialAnchorManager.cs` and scroll down to the method `GetAADTokenAsync`.

4. Comment out the line that throws the `NotSupportedException`.

5. Uncomment the remaining lines in the `GetAADTokenAsync` method. (These lines use the library we just downloaded to acquire the token.)

6. Update each **SpatialAnchorManager** in your project (or update **SpatialAnchorConfig** in the `AzureSpatialAnchors.SDK/Resources` folder) to use AAD, then specify your Client ID and Tenant ID.
