# Build an awesome Flutter app for Windows

Link to video: https://aka.ms/win-dev/student/osu/flutter/get-started-video
Link to blog: https://aka.ms/win-dev/student/osu/flutter/get-started-blog

You can follow the official documentation [here](https://flutter.dev/docs/get-started/install/windows) but we will provide all the steps required to prepare your development environment to build Flutter apps for Windows.

## Installing Flutter

In order to build your Flutter app for Windows, you need to have a few things installed on your system.
To install these dependencies, we recommend using [winget](https://docs.microsoft.com/en-us/windows/package-manager/winget/). Winget requires Windows 10, version 1809 (10.0.17763), or later. Lets start by going to the winget website:

https://github.com/microsoft/winget-cli/releases

From that page, download and install the latest available version. You only need to download the **Microsoft.DesktopAppInstaller_8wekyb3d8bbwe.msixbundle** file. After installing it, you should be able to install the other dependencies in a much easier way.

Simply open a Command Prompt or PowerShell window and type:

```winget install -e --id Microsoft.VisualStudioCode```

That is all that is needed to install VS Code. Easy, right? You also need a few other things, so lets start with **Git**:

```winget install -e --id Git.Git```

Next is Visual Studio 2019. If you don't have a professional license for Visual Studio 2019, then you can simply use the Community edition:

```winget install -e --id Microsoft.VisualStudio.2019.Community```

After installing Visual Studio 2019, open the Visual Studio Installer, where we will choose a dependency that needs to be present within VS. If you are having trouble finding it, just press the *Windows* they, then type "**Visual Studio Installer**". With the installer opened, click on *Modify* and make sure that the "**Desktop development with C++**" workload is selected. If it isn't, just select it and click on Modify on the lower right corner of the installer. This will ensure you have everything required to build your Flutter Windows Application. Just as some background, whenever you build your project, the Flutter commands will generate a native project to whichever platform that you are building for, and in the Windows case, it generates a native C++ Win32 application project, that uses Visual Studio 2019 to build your final executable.

Now, lets install the Visual Studio Code Flutter extension. Open Visual Studio Code, then in the extensions tab (you can use the *Ctrl+Shift+X* shortcut to open it) search for "**Flutter**". When you find it, select it on the list, and click "**Install**".

The only missing thing is to actually install Flutter. You can either download the zip file, or use git to clone from the source. Both options work exactly the same, so it is up to you to decide what you want to do. Follow Flutter's installation page to choose your installation method:

https://flutter.dev/docs/get-started/install/windows#get-the-flutter-sdk

Make sure you also update your system's path so you can call the Flutter commands from any command prompt. Just follow these instructions to update your path:

https://flutter.dev/docs/get-started/install/windows#update-your-path

Now that Flutter is installed, you need to run one simple command to enable desktop developments with it:
```flutter config --enable-windows-desktop```

That is it! You are now ready to start building your Flutter Windows app!

## Creating a new project
To create a new Flutter app, all you need to do is to call the "flutter create" command, providing the name of your project. Open your favorite command prompt, then change the directory to wherever you want to create the folder that will contain all your project's files. Flutter doesn't allow you to use upper case letters, so lets call it something simple, like this:

```flutter create my_flutter_windows_app```

It will create your project and restore it's dependencies.

Then just open VS Code within that directory:

```code my_flutter_windows_app```

All your code will now live within this folder. Open the *lib\main.dart* file, and make a simple change, such as changing the MyHomePage title property to your name.

Now, all that is left is for you to hack your project! If you want to learn more about Flutter and Dart, follow one of [Flutter's code labs](https://flutter.dev/docs/get-started/codelab). They are really great, and will be a great starting point for your hack!

## Building your project

Once you are ready to test your app, just type:
```flutter run -d windows```

The `-d` stands for device, so it means that you want to run your Flutter application on Windows. This might take a few seconds to build, but it will automatically start your Flutter app on Windows!

You can also use Visual Studio Code to build your project for you. Just press F5 and, if you are prompted, select the Windows device, which means your local Windows machine. This might take a few seconds to build, but you will then have all the powers of the Visual Studio Code Flutter extension to be as productive as possible to build your app!
