# MauiImageIssue

Intermittent issue loading images from local storage

## Description

I have simplified an app I have been working on. This app downloads images from the web and stores locally.

These are tehn shown in a content view bounde to a model of items.
Intermittently, the wrong image is showing.

For this sample app. I have a model class that contains a list of 4 images with a namd and url.
A content view on the main page is bount to ths list.

A button on the page randomises the images and rebinds the Bingding context.
On first click of the button, the images are downloaded and stored locally.

Intermittently, images are duplicated. 

In the folder Example errors, there are an example of one run of the app. Images seem to be wrong approximatly 1/30th of the time. Sometimes, I have clicked the button 100 time and nothing goes wrong.


# Versions

This project was created on a fresh machine with Maui project created from Visual Studio 17.4.4, Version shown below.

Videos above shown on Android Emulator_31. My original project were showing issues on Android phisical devices A22, J5 and J6


### dotnet --list-sdks
7.0.102 [C:\Program Files\dotnet\sdk]

### dotnet workload list

Installed Workload Id      Manifest Version       Installation Source
---------------------------------------------------------------------
maui-windows               7.0.52/7.0.100         VS 17.4.33213.308
maui-maccatalyst           7.0.52/7.0.100         VS 17.4.33213.308
maccatalyst                16.1.1477/7.0.100      VS 17.4.33213.308
maui-ios                   7.0.52/7.0.100         VS 17.4.33213.308
ios                        16.1.1477/7.0.100      VS 17.4.33213.308
maui-android               7.0.52/7.0.100         VS 17.4.33213.308
android                    33.0.4/7.0.100         VS 17.4.33213.308





