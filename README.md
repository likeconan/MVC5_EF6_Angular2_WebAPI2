#  Single Page Application Using Pro MVC5 EF6 Angular2 WebAPI2 Tutorial

## About the author

>I am a shinetecher, Yijia Li, from <a href='http://www.shinetechchina.com/' target="_blank">Shinetech</a> which provides outsourcing service to organizations.
I am interested in sharing the technologies I learned to help you and myself to understand them in deeply. If you have any problems please have
no hesitate to connect with me (Email:liyijia@gmail.com). Thanks for your reading.

## Contents at Glance

* [About starting this tutorial](#start)
* [Create your first application](#create)
* [Domain with EntityFramework](#domain)
* [WebAPI with Ninject](#webapi)


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

``Install-Package EntityFramework WebAPI``

> **[Tip:]** You can also install the package by clicking on ***Manage Nuget Packages for Solution***.The nuget package helps you to manage the tools you need. When you
want to run your application in a new development situation, the nuget will help you download all the tools again if the new development situation does not own them.

>Then put the following connectionStrings into *Web.config* files both in *WebUI* project and *WebAPI* project.(**Caution** I have to split  the value of *connectString* atrribute
across mulitple lines to fit it on the limited page,but its important to put everything on a single line in the *Web.config* file)

		<connectionStrings>
    			<add name="TutorialEfDbContext" connectionString="Data Source=(localdb)\mssqllocaldb;Initial Catalog=TutorialEfDbContext;Integrated Security=True;MultipleActiveResultSets=True" providerName="System.Data.SqlClient" />
  		</connectionStrings>

>### Create Model Classes and Implement Code First Pattern
> I added a class file to the *Entities* project folder called *Student.cs* and set the content as shown in below.

>**[Code:]** The Contents of the Student.cs File

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

>The next important thing you need to do is creating **DbContext**. Add a class file under the *Domian* project called *TutorialEfDbContext* and set the content as shown in below.

>**[Code:]** The Contents of the TutorialEfDbContext.cs File
		using System.Data.Entity;
		using Domain.Entities;


		namespace Domain
		{
    		public class TutorialEfDbContext:DbContext
    		{
        		// base("TutorialEfDbContext") is very important,because the string "TutorialEfDbContext" in it must be the same as connectionStrings name in the config file
        		public TutorialEfDbContext():base("TutorialEfDbContext")
        		{
            		Configuration.ProxyCreationEnabled = false; //disable proxy
            		Configuration.LazyLoadingEnabled = false; //disable lazy load
        		}
			//When you want to implement the entity into sql sever as a table, you need to add the Model as property in DbContext
        		public DbSet<Student> Student { get; set; }
    		}
		}


>Last but not least, using **Migration** command to create database in sqlsever.Open the *Package Manager Console* dialog again and make sure the default project is *Domain*,
and then successively execute the following commands.

>![Figure 8](/Materials/ch01/ch01-08.png)

>-   `Enable-Migrations`   *after the execution you will find that there is a Migrations folder created and Configuration file created under that folder*
-   `Add-Migration Initial`  *after the execution you will find that there is a named Initial suffix class file.Open the file you will see the Up and Down method
which represents the execution and rollback operation to the SqlSever, in other words it means creating the Student table and droping the Student table*    
-   `Update-Database -Verbose`  *after the execution when you open the SqlSever, you will find there is a database called TutorialEfDbContext,a table called Students and also
a table called MigrationHistory.*

>![Figure 9](/Materials/ch01/ch01-09.png)

> **[Tip:]** Once you enabled the migration to the project you don't need to do it again.The MigrationHistory table is used for keeping track to the changes you did to the models
 so that you can rollback or reproduce every change you want. In future I will tell you more operations with Migration so that it satisfies all cases you may need.

>### Summary

>In this chapter I told you how to use nuget *Install-Package* to manage your tools and also the essential commands to migration.And you may find that it's easy to create
a database in Sqlsever when using **Code First Pattern**,you only need to take the #C code into consideration.That's one of the important benefits to use that when you start
a complete new application.And the reason that you need to use **Migration** is that when trying to develop an application you will change the models inevitablely, then it
will help you update the database without losing the data you have created.

>In next chapter I will show you how to use **Dependency Injection(DI)** to create loosely coupled systems in  WebAPI. And aslo some basic applies in Web API 2.

## <a name="webapi">WebAPI With Ninject

>As you develop an apllication, in an ideal situation,each component knows nothing about any other component and only deals with other areas of application throught
abstract interfaces.This is known as **loose coupling**,and it makes testing and modifying applications easier.And what I need is a way to get objects that implement
an interface without having to create the object directly.The solution to this problem is called **dependency injection(DI)**,also known as **Inversion of Control(IoC)**

> **[Tip:]** Because this tutorial is all about using tools to create Single Page Application, I will not take more time on explaining DI.But you can check the details from
<a href="https://en.wikipedia.org/wiki/Dependency_injection" target="_blank">Wiki</a> or google other instructions about it.Don't worry if you don't understand DI right now,you can learn it by using it and
and imitating the code pattern to get the points of DI in future.

>### Install Ninject In WebAPI

>Select ***Package Manager Console*** in Visual Studio to open the NuGet command line and enter the following commands:

		Install-Package Ninject WebAPI
		Install-Package Ninject.Web.Common WebAPI
		Install-Package Ninject.Web.WebApi WebAPI
		Install-Package Ninject.Web.WebApi.WebHost WebAPI

>After install all of the packages.You will see there is a *NinjectWebCommon.cs* file created in App_Start project directory.In this class, check the *RegisterService* method which
is used for resolving your dependency injection.

> **[Tip:]** Don't worry that you don't understand what has been done in Ninject right now.The only things you need to care about is in *RegisterService* method, and you can check
more details in  <a href="http://www.ninject.org/" target="_blank">Ninject</a>.

>### Create Basic Crud In Domain

>I added two project folders under Domain project, one is called *Abstract* which is made of interfaces, the other is called *Concrete* which is made of extension classes.
As you know mostly we would get all entities, get one entity by its id,update one entity, add one and delete one, they are the basic operations.So I added an interface
called *IBasicCrud* in *Abstract* folder. the content of it is shown in below.

>**[Code:]** The Contents of the IBasicCrud.cs File

		using System.Collections.Generic;
		namespace Domain.Abstract
		{
    		public interface IBasicCrud<T>
    		{
        		List<T> GetAll();
        		T Get(string id);
        		bool Update(string id, T entity);
        		bool Add(T entity);
        		bool Delete(string id);
    		}
		}

>Then I added interface called *IStudentCrud* which implements *IBasicCrud*,the contents shown in below:

>**[Code:]** The Contents of IStudentCrud.cs File

		using Domain.Entities;
		namespace Domain.Abstract
		{
    		public interface IStudentCrud : IBasicCrud<Student>
    		{
        		//add custom method you need in here
    		}
		}

>Last thing is creating the StudentCrud Class in Concrete project folder, then contents shown in below:

>**[Code:]** The Contents of StudentCrud.cs File

		using System.Collections.Generic;
		using System.Linq;
		using Domain.Abstract;
		using Domain.Entities;

		namespace Domain.Concrete
		{
		public class StudentCrud : IStudentCrud
		{
				public List<Student> GetAll()
				{
						using (var context = new TutorialEfDbContext())
						{
								return context.Student.ToList();
						}
				}

				public Student Get(string id)
				{
						using (var context = new TutorialEfDbContext())
						{
								return context.Student.Find(id);
						}
				}

				public bool Update(string id, Student entity)
				{
						using (var context = new TutorialEfDbContext())
						{
								var res = context.Student.Find(id);
								res.Age = entity.Age;
								res.Name = entity.Name;
								res.Sex = entity.Sex;
								return context.SaveChanges() > 0;
						}
				}

				public bool Add(Student entity)
				{
						using (var context=new TutorialEfDbContext())
						{
								context.Student.Add(entity);
								return context.SaveChanges() > 0;
						}
				}

				public bool Delete(string id)
				{
						using (var context=new TutorialEfDbContext())
						{
								var res=context.Student.Find(id);
								context.Student.Remove(res);
								return context.SaveChanges() > 0;
						}
				}
		}
		}

>So far so good,you have created basic infrastructure with the BasicCrud interface.And here is the thing that you need to keep in mind.
When you find out there are some methods you would redo many times,you should refactor it into implementation so that you dont need to
write the methods again. Thats one of the important points for Object-Oriented Programming.

>### Binding Domain to WebAPI

>You already created basic data manipulations in Domain. The next you want to do is definitely using web api to apply them through browser url.
First of all, add the Domain as a reference in *WebAPI Project*, right click on *Reference* in *WebAPI Project* and then click on *add reference*
You will see a dialog says *Reference Manager - WebAPI*, select Projects - Solution and check on the Domain Project and click Ok as shown in below.

>![Figure 10](/Materials/ch01/ch01-10.png)

>Then I opened the NinjectWebCommon.cs File in *App_Start folder* and added this content in  RegisterServices method as shown:

    private static void RegisterServices(IKernel kernel)
    {
           kernel.Bind<IStudentCrud>().To<StudentCrud>();
    }

>**[Tip:] The RegisterServices method is used for adding binding so that you can use **Constructor Dependency Injection** in API Controller. Mostly you
will use just like my code here, I will show the other types of binding later when we use or you can check them out in <a href="http://www.ninject.org/" target="_blank">Ninject</a>

>### Using RESTful API

>When using Web API, it's a simple task to create a RESTful web service. Web API uses controllers just like the MVC framework, but the action methods return C# data
object rather than Razor views. Getting started is easy, to demonstrate how easy it is to get up and running, I right clicked the Controller folder in Web API Project,
selected *Add* - *Controller* from the pop up menu, selected the *Web API2 Controller - Empty * template, and name it StudentsController.

>**[Tip:]** There are two important namespaces in Web API development: **System.Net.Http** and **System.Web.Http**.
Web API relies on an abstract model of HTTP requests and responses that is defined in **System.Net.Http**. The classes
from this namespace that you will work with most often are HttpRequestMessage and HttpResponseMessage, which are
used to represent an HTTP request from the client and the response that will be sent in return.

>I used Constructor Dependency Injection in this controller, and created regions so that making the whole code clear and clean. The contents of StudentsController.cs is shown in below:

>**[Code:]** The Contents of StudentsController.cs File

    using System.Collections.Generic;
    using System.Net;
    using System.Net.Http;
    using System.Web.Http;
    using Domain.Abstract;
    using Domain.Entities;

    namespace WebAPI.Controllers
    {
    public class StudentsController : ApiController
    {
        #region Fields

        private IStudentCrud _student;

        #endregion

        #region Constructor

        public StudentsController(IStudentCrud student)
        {
            _student = student;
        }
        #endregion

        #region SLP

        public IEnumerable<Student> GetStudents()
        {
            return _student.GetAll();
        }
        public Student GetStudent(string id)
        {
            return _student.Get(id);
        }

        public bool PostStudent(Student student)
        {
            return _student.Add(student);
        }

        public bool DeleteStudent(string id)
        {
            return _student.Delete(id);
        }

        #endregion
    }
    }

>Then I right clicked the WebAPI project, selected *Debug - Start new instance* from pop up menu. You will see the project is running and a new site opened in your default browser.
And use the browser to request the following url: http://localhost:35081/api/students/conan **(you may have different port number in your situation, just replace my 35801 with yours number).**
If everything is working correctly, then you will see the following response displayed in browser window.
    <Student xmlns:i="http://www.w3.org/2001/XMLSchema-instance" xmlns="http://schemas.datacontract.org/2004/07/Domain.Entities" i:nil="true"/>

>The response is an XML document that describes the Student from database, whose Id property corresponds to the one I specified in the url,
since we don't create any data right now, its an empty node.
