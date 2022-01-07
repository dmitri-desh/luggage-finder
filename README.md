# luggage-funder

Luggage Finder

Client

People who travel on plane sometimes face with situation that their luggage has been lost. So, we decided to create a service that should help them to find it. They can open our web site and on the main page they will be able to fulfill all required fields and click ‘Find’ button.

	Required fields: 
  
1.	First Name - (text field)
2.	Last Name - (text field)
3.	Email - (text field)
4.	Phone Number - (text field)
5.	Destination Address – (text field)
6.	Departure Airport - (dropdown field)
7.	Arrival Airport (dropdown field).
 
To make it simpler let’s imagine that we have only 10 Airports:

•	Moscow

•	London

•	New York

•	Oslo

•	Amsterdam

•	Frankfurt

•	Warsaw

•	Tokyo

•	Minsk

•	Istanbul

Please create a many to many relationships between airports, so when you select Departure Airport in the Arrival Airport dropdown loading only realated flights.
When user click ‘Find’ button we should save fields to the database, generate track number (like ‘ABCD123’) show it on the success page and send him that track number on his Email Address.

Employee

Also, there should be and employee that using our service will do all the job to find the luggage and notify client about its request delivery status.

List of statuses: 

•	Accepted

•	Found

•	OnTheWayToArrivalAirport

•	OnTheWayToDestinationAddress

•	Delivered

Employee could login to the system using its username and password and access admin page where he can see the list of client’s requests.

Example:

First Name	Last Name	Email	Departure	Arrival	Track Number	Status	

John	Doe	jdoe@example.com Moscow	New York	ABCD123	Accepted	details

Jane	Air	jairs@example.com Oslo	Warsaw	CDRF231	Found	details

Glenn	Brown	gbrown@example.com Amsterdam	Tokyo	REQW331	Delivered	details

…							

For each request in the list you should have a link that will redirect you to the details page. On details page employee can see all details and can update status (dropdown field). 
When employee update status and press save button then new status should be saved to database and client should be notified via email address about the status of his luggage.

Please create a repository on github. It would be nice if you implemented it as a single page application (angular/react) + ASP.NET WebAPI. If it easier to implement it using ASP.NET MVC it is also ok. Please, use Entity Framework Code First approach to work with database. Use Identity Server 4 to implement authentication and authorization staff. Would be nice to have Unit Tests. 

