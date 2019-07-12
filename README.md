
# Spend-It 

A simple ASP.NET Core 2.2 MVC web applications using Entity Framework (EF) Core. 

The app allows you to search and locate Businesses that accept cryptocurrency as pament.

Spend-It allows users to search for locations that accept cryptocurrency(*Only avaliable in select City's) 
![image](https://github.com/Downeastrussell/Spend-It/blob/master/Spend-It/wwwroot/Pictures/SpendIt.png)

A user can view a list of all Locations immediately upon visiting the site.
Locations can be sorted or searched by city, location type, location name, or search the short description for each location.
![image](https://github.com/Downeastrussell/Spend-It/blob/master/Spend-It/wwwroot/Pictures/Home.png)

If the user would like, they can register and login to add their own Locations or save Locations that other users have created. Locations can be edited or deleted, but only by the user who created them. 
![image](https://github.com/Downeastrussell/Spend-It/blob/master/Spend-It/wwwroot/Pictures/Create.jpg)

One of the best features of this app is that the user can search all Locations by City. So if a user finds themselves in a particular City and isn't sure where they can spend their Cryptocurrency, the user can check the app and easily locate all the Businesses in their current City, whether it be hotels, restaurants or grocery stores.

Technologies:
C#/ASP.NET w/Entity Framework and Identity


TO GET THIS PROJECT-
Requirements: Microsoft.NET Framework and Visual Studio
Directions:
1) Fork the repo
2) Navigate to the '.sln' file in the project via gitbash
3) Start 'Spend_It.sln'
4) Adjust your app settings in the appsettings.json file to show your server name instead of the current one
5) Run 'dotnet ef database update' in the command line to get the database for the project
6) Hit the green 'play' IIS button at the top of Visual Studio to build the project in the browser(or CTRL-f5)
