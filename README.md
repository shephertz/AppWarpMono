AppWarpMono
===========

Cross platform portable dll for MonoDroid and MonoTouch. This will allow you to build cross-platform multiplayer games
on iOS and Android using C#/.NET skills by leveraging the powerfull AppWarp (http://appwarp.shephertz.com) real time
cloud gaming network.

This repo contains the dll built using MonoDevelop and targeted towards Mono Portable profile. 
This means the same dll will work in your MonoDroid applications targetted for Android as well as
you MonoTouch application targetted towards iPhone.

Pre-requisites

This assumes that you have setup your MonoDevelop IDE for the platform that you are trying to build for (iOS/Android etc).
If you haven't done that, you can get started on that by visiting http://docs.xamarin.com/


Steps for integrating AppWarp in to your Mono project

The steps are quite straight forward

1. Download the zip file from this repo and unzip the contents.

2. Open your application's solution

3. Add references to the unzipped dlls i.e. AppWarpMonoCompat.dll and Newtonsoft.Json.dll

4. You can now add references to WarpClient and start using it in your application!


How to use the Samples 

1. Login/Sign-up on AppHQ (ShepHertz developer dashboard) @ http://apphq.shephertz.com

2. From the dashboard, create a new app of type appwarp cloud gaming.

3. Note its keys – you will require them to initialize the SDK in your code.

4. From the dashboard, create a new room with 2 max players. Note its room id – you will require this in your code.


Android Sample

This is based on the Hello, Android project available on Xamarin tutorial. This sample shows how to
integrate the AppWarp dll in your project. Follow the steps mentioned under above on integrating AppWarp into your
Mono Project and apply them to the sample. Add the keys you got from AppHQ and add them to Activity1.cs file where 
indicated. You are now ready to build!

iOS Sample

This is based on the Hello, iPhone project available on Xamarin tutorial. This sample shows how to
integrate the AppWarp dll in your project. Follow the steps mentioned under above on integrating AppWarp into your
Mono Project and apply them to the sample. Add the keys you got from AppHQ and add them to HelloWorld_iPhoneViewController.cs 
file where indicated. You are now ready to build!
