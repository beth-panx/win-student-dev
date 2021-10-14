# Getting started with UWP and Microsoft Graph

Hello and welcome! In this getting-started guide you will learn how to add contextual user data and intelligence from the Microsoft Graph service into a modern UWP application.

## What is UWP?

## What is Microsoft Graph?

## Overview

In this guide we'll walk through:

1. Enabling user authentication by setting up an app registration in Azure.
2. Adding the Authentication and Graph nuget packages from the Windows Community Toolkit.
3. Creating a new UWP project in Visual Studio (or bring your own).
4. Setting up the global authentication provider.
5. Adding a Graph-powered control to enable login.
6. Making an ad-hoc call to any Microsoft Graph API.

## What you'll need

To complete this guide you'll need the following:

- A device running Windows 10 or 11 OS
- An internet connection
- A personal Microsoft account

Now fire up Visual Studio and let's get started! 🚀

## Create an app registration to enable user authentication

In order for authentication and login to work in your app, we must first create a relationship between your application and Microsoft identity services. This is a security step that prevents unknown applications from querying user data.

[Sign up for a free Microsoft Azure account](https://azure.microsoft.com/en-us/free/) and use Azure Active Directory to create an *app registration*.

Follow this walk-through to setup a new app registration in Azure Active Directory - [Quickstart: Register an application with the Microsoft identity platform](
https://docs.microsoft.com/en-us/azure/active-directory/develop/quickstart-register-app)

Give your app registration a name that can be displayed in an authorization prompt. This is so users know what app is requesting access to their Graph data when granting consent.

When selecting a sign in audience, consider using **Accounts in any organizational directory and personal Microsoft accounts**. This is the most flexible option that will work with public Microsoft accounts (Outlook, HotMail) as well as organizational accounts from work or school.

When you've completed creating and configuring the app registration, record the **Client ID** value to use in the application later on.

## Create a new UWP project or BYO

You'll need a UWP application as a baseline. If you already have a UWP project setup and ready to infuse with user insights from Microsoft Graph, please continue to the next step.

To create a new UWP app, let's start by using the **Create a new project** option:

1. Find the project template, **Blank App (Universal Windows)**
2. Give your project a name and location. I chose: `C:\Git\UwpGraphQuickstartSample`
3. Click the **Create** button to complete the wizard and create your new UWP application.

> IMAGE - of VS app creation screen

## Add nuget packages from the Windows Community Toolkit

With your UWP project open in Visual Studio, find the **Project** menu item. Select **Manage NuGet Packages...**

> IMAGE - of nuget package manager

Navigate to the **Browse** tab if you are not already there by default.

Use the search input field to lookup and install the latest versions of the following packages:

- `CommunityToolkit.Authentication.Msal`
- `CommunityToolkit.Graph.Uwp`

> IMAGE - of the installed nuget packages in the packman

## Setup a global authentication provider

To start making Graph API calls, we must first authenticate the user and get authorization to request their data from Microsoft Graph. Start in the app startup logic, `App.xaml.cs`

```
using CommunityToolkit.Authentication;

// Set the global auth provider when launching/activating the application.
private void ConfigureGlobalAuthProvider()
{
    if (ProviderManager.Instance.GlobalProvider == null)
    {
        var clientId = "YOUR-CLIENT-ID-HERE";
        var scopes = new string[] { "User.Read" };

        ProviderManager.Instance.GlobalProvider = new MsalProvider(clientId, scopes); ;
    }
}
```

## Enable user login with the LoginButton control

To trigger the login flow for users, we will next add a `LoginButton` control. This button will call sign in/out on the global auth provider when invoked by the user. It is also aware of the global provider state and will react and automatically update representation and function accordingly.

Open up the page where you want to put your login button, such as `MainPage.xaml`

```
<Page
    x:Class="UwpGraphQuickstartSample.MainPage"
    xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
    xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
    xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
    xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
    xmlns:controls="using:CommunityToolkit.Graph.Uwp.Controls"
    mc:Ignorable="d"
    Background="{ThemeResource ApplicationPageBackgroundThemeBrush}">

    <StackPanel>
        <controls:LoginButton />
        <TextBlock x:Name="SignedInUserTextBlock" />
    </StackPanel>
</Page>
```

## Make an ad-hoc request to a Microsoft Graph API

Now that our user can login, we can request access to data from Microsoft Graph APIs. Make sure to check the state of the current global auth provider and see if a user is signed in before making Graph requests. Otherwise any calls to Graph will not be authenticated and return a status code 401, **Forbidden**!

```
using CommunityToolkit.Authentication;
using CommunityToolkit.Graph.Extensions;
using Windows.UI.Xaml.Controls;

public sealed partial class MainPage : Page
{
    public MainPage()
    {
        this.InitializeComponent();

        ProviderManager.Instance.ProviderStateChanged += OnProviderStateChanged;
    }

    private async void OnProviderStateChanged(object sender, ProviderStateChangedEventArgs e)
    {
        if (e.NewState == ProviderState.SignedIn)
        {
            SignedInUserTextBlock.Text = "Signed in as...";

            var graphClient = ProviderManager.Instance.GlobalProvider.GetClient();
            var me = await graphClient.Me.Request().GetAsync();

            SignedInUserTextBlock.Text = "Signed in as: " + me.DisplayName;
        }
        else
        {
            SignedInUserTextBlock.Text = "Please sign in.";
        }
    }
}
```

## Running the application

## Now what?
