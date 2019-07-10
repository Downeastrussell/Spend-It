
# Spend-It 

A simple ASP.NET Core 2.2 MVC web applications using Entity Framework (EF) Core. 

The app allows you to search and locate Businesses that accept cryptocurrency as pament.

Check out Spend-It at https://spendit.com

Spend-It allows users to search for locations that accept cryptocurrency(only avaliable in select city's). 


About Spend-It:
A user can view a list of all recommendations immediately upon visiting the site. If the user would like, they can register and 
login to add their own recommendations. Recommendations can be edited or deleted, but only by the user who created them. A user 
can add a neighborhood if they would like, or they can just choose 'Other' in the 'Neighborhood' drop-down in the create form. 
There are three categories of recommendations that the user can choose from while creating recommendations.

One of the best features of this app is that the user can search all recommendations by neighborhood. So if a user finds themselves
in a particular neighborhood and isn't sure where to go next, the user can check the app and easily locate all the recommendations
in their current neighborhood, whether it be live music, comedy or coffee.

Technologies:
C#/ASP.NET w/Entity and Identity

This site is live at: https://spendit.com

TO GET THIS PROJECT-
Requirements: Microsoft.NET Framework and Visual Studio
Directions:
1) Fork the repo
2) Navigate to the '.sln' file in the project via gitbash
3) Start 'Spend_It.sln'
4) Adjust your app settings in the appsettings.json file to show your server name instead of the current one
5) Run 'dotnet ef database update' in the command line to get the database for the project
6) Hit the green 'play' IIS button at the top of Visual Studio to build the project in the browser(or CTRL-f5)
