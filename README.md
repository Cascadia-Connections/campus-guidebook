# campus-guidebook
Cascadia-UWB clubs, events and sustainability features

Spring Quarter Team 2022 Summary:
Throughout the the quarter we had created a login for a Administrator/Moderator/Viewer. After registering an account the account will appear in the AppIdentity Database. You then will need to go to that database to distinguish whether or not they're one of the 3 roles above. We had also created a way for the user and moderator to create, edit, approve/deny an event, as well as a way for the admin to send back to the moderator conditions to improve on their application in order to be approved. You will need to hook up that part to the database to save to the database as well as a way for the web app to send that to the moderator. The events will all go straight to pending upon creation for approval. If they're denied or approved they will also go to the correct category on the page. The web app will also hide tabs/pages depending on their role, for instance a moderator will not have the option to approve or deny events so they will not be able to see that page. The events are also tied to the user that had created the event, so you will need a way for the admin to be able to see ALL events regardless of who applied. The client also asks that the events be grouped under a tag for each club. For instance you should be able to display all of the events for the art club. Also should be able to filter the events. Also I had left off some categoires for the event application as well as edit events for testing, the categories SHOULD MATCH the events model or you can look at event response for more information. You will need to in to the database to turn off alow nulls for these categories. If the admin is editing events then once they hey apply it should automatically approve the event. For a moderator there should be a category for "Needs improvement" or something along those lines for the application they need to fix in order for the admin to approve it. Below are all of the feedback notes we had received from the client so you may refence it.

Taylor, Micah, Andrew notes:
Website is here to support the mobile app

Backing up the mobile event 
Having it visually as different tabs and filter for one type of event, pending event first makes sense

Seeing approved or denied doesn’t matter too much, more information on the event
Having description and date on the eventinfo page, who the club is, title, name, date, filter by date or sort by date or sort by club, or when it was submitted

Having a heading at the top of table to have sort of a hyperlink

Not really a need for a Event Response tab since we click on it already in EventInfo
See the image rather than url, longitude or latitude doesn't matter
Event Date needs to be added in, display the img and date should be after description
Name date description last updated location club
Have name and date and location in the EventInfo page and the club
Have a textbox and a textbox with a request change button
Heading should be “Administrative Change” Instead of approve or reject event on EventResponse
Title should be “Requested Event” for Event Response Page, subtitle can be administrative response

Page Layout: /*
Title, 
Event Name, club name, event date,  event location, event description, img
Administrative Response, Drop down: approve, request change reject
Textbox, submit
/*


If request change is chosen than the textbox MUST have a value
Liked how it went straight to the next pending event
Event Name, event date, event location
Combine the event response and the event info page so that you can scroll down the page
For now keep it 2 pages
Keep 1 img in the event response page
Add in the users email so it shows who sent in the request
Event data collection isn’t important
Google Map for event location isn’t important
Connect with mobile app api so people can see the event information
Provide API to mobile app of all of the current events that have been approved
Using .NET/Rest API for the api
Create an event as a club organizer to then send it to the reviewer/admin from the web app
Create 2 different log ins for club officer and admin
Admin can create event 
After approval it should show on the mobile app


Client Meeting #2


date to track by pending
Some events need to be approved sooner And will need to see the sooner events quicker
The type of event like a tour or external event

date name category location
At least have the notes for the rejection so they have a note saying why it was rejected
Try not to have an auto email for the rejection
Users can be able to log in to see the rejection on the event
Common reasons why events are rejected on a different page
Make edits on the post as the admin so that all of text is editable 
Likes the list format and the event description is on the other page

Prefers to have ~16 characters for password
Additional page for non admin pages
An option for image upload for event creation
Would like an image on the listing page for events
A page to see all the status of all the events they have made
Tiles for energy ideas or a content section or like educational tiles (might out of our time range)
My events page added
Other categories for admin to edit or change in the future called content editor
Keep the event approve denied and pending on the same page
Once the event has passed the event would be auto removed and/or an option to remove the event altogether?

Create option for mobile app editing through rest api
User Submission, Rest API, authorization/authentication for user


Meeting 3


Liked the moderator page
Likes that the the event is auto assined to the pending
Sould have the ability to pop up a warning when an event cannot be added to the DB
Allright with clubs being tied to a user. 
Likes that viewers will not be able to see the edit button
Would like a perent grouping for users wether that means some are admin, moderator, or viewer example: art club accounts
Be able to see who uploaded the event as an admin
General grouping of events as a tag. Moderators able to select the type of event and Admins will be able to assign tags to these events
Admins and users would be able to search though types of events as "Outdoor" events as an example.
There needs to be a visable way to tell wether you as a moderator has your event rejected.
Sould be able to see the difference between Denided or rejected.
As a moderater have the ability to resubmit your rejected event.
add a new row to the DB for a Resubmitted category. The moderator would beable to see the reason their event had been rejected. This might show up as a red flag or something in their event lists
Just need a filter for the types of events. No need for a search box for this type of project.
Be able to see what selected tags are in use.
If you are an admin you should be able to bring an event to accepted when edditing an event. This page would allow to accept and rejected.
Should have a filter for the events
Need to categorize each event under a club on a page
Need to have an admin be able to see all events and be able to edit any event not just their event so since event is tied to account need to figure out how to get all events and be able to edit
Add in a category on event to show that it was amended for approval.
Add in a new category for event status that says that the event is back for amendments.

