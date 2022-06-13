# RestaurantAssessment
 RestaurantAssessmentRestAPI
 
 * This Project includes .net core framework 5.0
 * Within the scope of the project, swagger has been integrated in order to be easy to use and test.
 * JWT token is used for authentication.
 * Some concepts that came with C# 9.0 were tried to be used. Like 'record, init'
 * An attempt has been made to stick to the basics of Dependency Injection.
 * Using ServiceProvider to implement dependecny injection
 
 
Three different users for the program to run. The usernames and passwords of these users are listed below.

Restaurant User : rest, rest

Client User : cus, cus

Guest User : guest,guest

Authorities of the restaurant user:
* Can create a daily menu.
* Can list daily menus
* Can update daily menus
* Can delete daily menus
* Can view orders by order number
* Can view all orders
* Customer can see orders by number.

Authorities of the customer user:

* Can see daily menu list
* Can create order
* Can view your order

Authorizations of the Guest User:

* Can view Daily Menu list

In addition, the user adding service has been activated for testing of an external user. You can create a restaurant, guest or customer user
