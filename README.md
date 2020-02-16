# to-do-demo-dotnetcore-react
A simple to-do web app composed of a .Net Core REST API and a react front-end

Published on my Github repo at https://github.com/luisgonzalo/to-do-demo-dotnetcore-react

## How long did you spend on your solution? ##
About 5 hours

## How do you build and run your solution? ##
Backend: VS 2019, Run
Frontend: VS Code, npm start

## What technical and functional assumptions did you make when implementing your solution? ##

## Explain briefly your technical design and why do you think is the best approach to this problem. ##
Backend keeps a static in-memory list, so the list is there until the backend is stopped and this list is shared by all clients. So, there is no persistence in database. To implement persistence, a new class implementing the ITodoSevice interface would be enough, and the dependency injection on Startup.cs to inject this class.
Frontend

## If you were unable to complete any user stories, outline why and how would you have liked to implement them. ##
