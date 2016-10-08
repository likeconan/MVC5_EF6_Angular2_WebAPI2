#  Single Page Application Using Pro MVC5 EF6 Angular2 WebAPI2 Tutorial


## Contents at Glance

* [About starting this tutorial](#start)
* [Create your first application](#create)
* [Domain with EntityFramework](#domain)



## <a name="start">About Starting this Tutorial


>### What Do I Need to Know?

>To get the most from this tutorial, you should be familiar with the basics of web development, have an understanding of how HTML and CSS work
and a working knowledge of C# and Javascript. Don't worry if you are a beginner, there are a lot of examples and I will introduce step by step from sever-side to client-side.


>### What Is the Structure of This Tutorial

>This tutorial is split into 2 parts, each of which covers a set of related topics.

>#### Part 1:Server-Side Development

>I start this tutorial by creating a real online school management single page application so that you know how to create, update database in sql sever by using Code
First Pattern in EntityFramework 6. And also you will touch on major features of  the ASP.NET MVC Framework and WebAPI2.

>#### Part 2:Client-Side Development

>In Part2, I explain how to bind angular with ASP.NET MVC5 and WebAPI2 so that you can success in creating a Single Page Application. Furthermore, I will
also show you how each feature works in angular, explain the role and guide it play in client side.


>### What Software Do I Need for This Book?

>The only software you need for this tutorial is Visual Studio 2015, which contains everything you need to get started; An administration-free editon of Sql Sever 2012 or above;
node.js for getting the latest Angualr 2.
There are several different versions [Visual Studio Downlaod]("https://www.visualstudio.com/downloads/"), each of them would work fine. Once you have installed Visual Studio
,Sql Sever,NodeJs, you are ready to go.

>### Summary
>In this chapter, I explained the structure of this tutorial and the software that you will require to follow the examples.
    In next chapter, you'll see how to start a project in a expandable way.


## <a name="create">Create Your First Application


>### Create a Blank Solution
>Select ***New Project*** from the ***File*** menu to open the ***New Project*** dialog. If you select the ***Installed*** and open ***Other Project Types***. You 
will see the ***Blank Solution*** project.Select this project type. As shown in below

>![Figure 1](/Materials/ch01/ch01-01.png)


> Set the name of the solution to **Tutorial** and click the ***Ok*** button to continue.Then, right click the Solution in Solution Explorer, Select ***Add*** and click
on ***New Project***. As shown in below

>![Figure 2](/Materials/ch01/ch01-02.png)

>You are seeing the New Project dialog again, this time please select ***Web*** Template, you will see the ***ASP.NET Web Application*** project template. Select this project
type as shown in below

>![Figure 3](/Materials/ch01/ch01-03.png)

>Set the name of the project to **WebUI**, it will contains all the features of MVC and Angular we use for our application. Click the ***OK*** button to continue. You will see
another dialog box, shown in below, which asks you to set the initial content for ASP.NET project.To keep things simple and tell you the knowledge from beginning:select the
***Empty*** option and check the ***MVC*** box in the ***Add folders and core references*** section, as shown in the figure.This will create basic web application which
contains MVC5 reference.Click the ***OK*** button to create the new project. 

>![Figure 4](/Materials/ch01/ch01-04.png)

>Next, create another new project which is named **WebAPI**, the same steps like you create **WebUI** project, except you check the ***Web API*** instead. Click the ***OK***
button to create **WebAPI** project as shown in below.

>![Figure 6](/Materials/ch01/ch01-06.png)

>Last, create **Domain** project for data access and operation. Select ***Visual C#*** and open ***Class Library***, click ***OK*** button as shown in below.Then all of
the preparations are done, you are ready to code now.

>![Figure 5](/Materials/ch01/ch01-05.png)

> **[Tip:]** You may wonder why I need to create three projects to build one single page application, does one project make all features work?The answer is yes.But as you start to build application, you need to make the whole project as clear as possible.Keep in mind that the code should be readable by **People** not **Computer**.So create three projects seems like you arrange different type of stuff into drawers organized.You and others will find what he wants quickly and accurately.

>### Summary

>So far so good. In this chapter I told you how to create a blank solution, MVC template, WebAPI template in steps. And also the reason why we need to create three projects
to build the application.Next chapter I will show how to use **Code First** Pattern with EntityFramework 6 to create your models and database in Sql Sever. Moreover, how to 
use **Migration** to fulfill the developing extensible in database cases.


## <a name="domain">Domain With EntityFramework

In this chapter,I am going to show you how to use **Nuget** to manage your tools during the developing process.In addition your first model in **Code First** Pattern,
and also the basic commands in **Package Manager Console** for **Migration** in EntityFramework.

>### Using Nuget to Install EntityFramework
>Open ***Tools***,select ***Nuget Package Manager*** and click ***Package Manager Console***,then you will see the Package Manager Console dialog opened as shown in below.

>![Figure 6](/Materials/ch01/ch01-07.png)

>Next execute these commands respectively.

``Install-Package EntityFramework Domain`` 

``Install-Package EntityFramework WebUI``

> **[Tip:]** You can also install the package by clicking on ***Manage Nuget Packages for Solution***.The nuget package helps you to manage the tools you need. When you 
want to run your application in a new development situation, the nuget will help you download all the tools again if the new development situation does not own them.

>### Create Model Classes and Implement Code First Pattern
> I added a class file to the *Entities* project folder callded *Student.cs* and set the content as shown in below. 
>*Code* The Contents of the Student.cs File

		using System.ComponentModel.DataAnnotations;
		namespace Domain.Entities
		{
   		public class Student
    		{
        		// Every Model must has its Key attribute, it represents the Primary Key in Sql Server
        		[Key]
        		public string Id { get; set; }
        		public string Name { get; set; }
        		public int Age { get; set; }
        		public bool Sex { get; set; }
    		}
		}
