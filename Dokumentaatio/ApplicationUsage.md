# About the application

## Application usage

Application was created to advance personal life management skills, achieving this with creating tasks, viewing them and removing them as the tasks been done. The Task Manager application is for personal use, where user creates a profile and includes personal tasks on their account. User can write down a task description to specify tasks. Tasks can be marked as done, which gives the user a possibility to track their personal progress.

## Users

Only one user can use the application at a time.

## Description of applications structure

Task Manager app consist of four separated views as well as one view laid on the main view. The views are :

- Main Menu view, the start menu where user either create an account or log in with an existing account
- Sign In view, user creates a personal account granting them access to the main program itself
- Log In view, user logins to an existing account leading the user to the main program
- Main Program view, the main view where user can start creating tasks, mark them as done and removing them
- Task creation view, part of the main program, a pop up panel which is necessity for task creation

## Functionality

Before the user can start using the main program (creating tasks), the user must create an account.
  ### Creating the user account: 

- Unique username, the application sends an error message if the username already exists
- The input fields must contain something for the sign in button to become interactable, app sends error message if this is not the case
- User sees error messages if password doesn't meet the regulations (at least 6 characters in length, consisting of at least one uppercase letter, digit and special character)
- Application crypts the password when account's been succesfully created (BCrypt as a remote library)

### If user already has existing account they can just straight login: 

- If account was not found the application will inform the user by sending a error message, once again
- Input fields must contain text, otherwise the log in button will not be interactable
- If the username or password's not correct, the applications great error message will let the user know

### After user's been logged in

Main view consist of user profile form stating "Welcome *username) and an animated character as "profile picture", add task button, task and description forms, task creation form and last but not least the log out button.

The user is adviced to start creating tasks on the main view.

- The user clicks "Add Task" button and the new task form opens up
- User defines tasks title and description (Notice: User must have text on both fields, so that the task can be created)
- Once the above is done, user can add task by clicking "Add Task" button, to confirm.
- User can set task as done, the toggle is located on the left side of task form, arranging the tasks so that the done task will be on the bottom
- User can also remove tasks, clicking the red cross on the task forms upper right corner
- When user wants to exit the application, they must log out, leading them to the main menu to let them press the big red "QUIT", closing the application