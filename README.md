AppWarpMono
===========

Cross platform portable dll for MonoDroid and MonoTouch. This will allow you to build cross-platform multiplayer games
on iOS and Android using C#/.NET skills by leveraging the powerfull [AppWarp](http://appwarp.shephertz.com) real time
cloud gaming network.

This repo contains the dll built using MonoDevelop and targeted towards Mono Portable profile. 
This means the same dll will work in your MonoDroid applications targetted for Android as well as
you MonoTouch application targetted towards iPhone.

[Getting Started](https://github.com/shephertz/AppWarp_WP7_SDK_DLL/wiki/Getting-Started)

[Reference](https://github.com/shephertz/AppWarp_WP7_SDK_DLL/wiki/Reference)

[FAQ](https://github.com/shephertz/AppWarp_JAVA_SDK_JAR/wiki/FAQ)

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

1. Login/Sign-up on [AppHQ](https://apphq.shephertz.com/register?appwarp=true) (ShepHertz developer dashboard)

2. From the dashboard, create a new app of type appwarp cloud gaming.

3. Note its keys – you will require them to initialize the SDK in your code.

4. From the dashboard, create a new room with 5 max players. Note its room id – you will require this in your code.


Android Sample

This Android sample shows how to build a cross platform chat application by integrating the AppWarp dll in your MonoDroid project. 
Follow the steps mentioned under above on integrating AppWarp into your Mono Project and apply them to the sample. 
Add the keys you got from AppHQ and add them to Constants.cs file where indicated. You are now ready to build!

iOS Sample

This iPhone sample shows how to build a cross platform chat application by integrating the AppWarp dll in your MonoTouch project. 
Follow the steps mentioned under above on integrating AppWarp into your Mono Project and apply them to the sample. 
Add the keys you got from AppHQ and add them to Constants.cs file where indicated. You are now ready to build!


Third Party binaries and licenses used
JSON.NET

(http://json.codeplex.com) The MIT License (MIT) Copyright (c) 2007 James Newton-King

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
