# to-do-demo-dotnetcore-react

A simple to-do web app composed of a .Net Core REST API and a react front-end

Published on my Github repo at https://github.com/luisgonzalo/to-do-demo-dotnetcore-react

## How long did you spend on your solution? ##

About 5 hours

## How do you build and run your solution? ##

1. Backend: VS 2019, Run

2. Frontend: VS Code, npm start

## Explain briefly your technical design and why do you think is the best approach to this problem. ##

Backend keeps a static in-memory list, so the list is there until the backend is stopped. This list is shared by all clients. So, there is no persistence in database. To implement persistence, a new class implementing the ITodoSevice interface would be enough, together with the dependency injection on Startup.cs to inject this class when the ITodoService is instantiated in the Task controller constructor. 

All the logic is implemented in a TodoService class, and this class has full test coverage. There is single api controller class with skinny methods to handle the standard GET, POST and PUT verbs. No logic is put in this controller, business logic is implemented in the TodoService class.

Frontend: uses Material-UI, the Material Design implementation for React. Uses the standard javascript fetch to make the api calls. Uses react-toastity for user notifications.

## If you were unable to complete any user stories, outline why and how would you have liked to implement them. ##

I did not implemented tests in the frontend, only in the backend, where all the logic is. However, it would have been interesting to do it: mock the api calls, test that when something is typed in and the add button is clicked then a new list element is created, and test that when a item checkbox value is changed then the item is moved into the other group.
