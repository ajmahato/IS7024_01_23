# IS7024_01_23
***

![MicrosoftTeams-image (8)](https://github.com/ajmahato/IS7024_01_23/assets/143025251/01b32ecd-d9f3-4ea3-a411-4a37ec929d73)

Design Document  
- Ajay Mahato  
- Mohammed Tahir Madni  
- Nishit Raj  
- Ranjay Bose  

## Introduction
***
Are you tired of the monotony in your daily routine. From work or school on weekdays to city exploration on weekends? Do you long for the exhilaration of adventure and the thrill of venturing off the beaten path? We have the ideal solution for you.  

Introducing **HikeIt**, your ultimate weekend getaway companion. We proudly present a meticulously curated selection of hiking trails from across the United States, guaranteed to ignite your sense of adventure. What sets us apart is we don't just provide you with trail information; but also offer insights into the surrounding areas. This allows you to plan your entire weekend escape, including accommodation, dining, and more.

## Storyboard
***
![MicrosoftTeams-image (7)](https://github.com/ajmahato/IS7024_01_23/assets/37789394/244c2341-5ddd-4f37-9d36-0300a9106cac)

## Data Feeds
***
[National Park Service](https://www.nps.gov/subjects/developer/api-documentation.htm#/campgrounds/getCampgrounds)  
[Wearther Bit](https://www.weatherbit.io/)  

## Functional Requirements

### Requirement 100.0 : Look up different National parks in my state.

**Scenario**

As a user, I want to get a list of National parks in my state of residence.

**Dependencies**

National park information is available along with weather information for that area.

**Assumptions**

a) API might not cover all possible geographical locations

b) API providing National Park data will be available and reliable.

c) User will have to manually enter their state if application is not able to access user location.

**Example**

**1.1**

**Given** a list of possible National parks is the state.

**When** I select “Yosemite National Park”

**Then** I should be directed to a page that gives me a brief overview of Yosemite National Park. Some of the points to be covered in the overview are

- Address 
-	Weather
-	Pictures of the location


### Requirement 101.0: Look up the weather at a hiking spot

**Scenario**

As a user, I want to weather related information about a hiking spot that I’m planning to visit.

**Dependencies**

Weather data is available via the weather API

**Assumptions**

API will provide the current weather weather forecast and also inform the use if it’s safe to travel to the selected location.

**Example**

**1.1**

**Given** I’ve selected Yosemite National Park, along with the overview I’ll also get an option to check out the weather at that location.

**When** I choose to check out the weather

**Then** I should get the current climatic conditions which include the points

a)    	Whether or not its raining heavily

b)    	Whether its too hot to hike at the spot

c)    	7 day weather forecast



## Scrum Roles
***
- Backend Developer/ product Owner: Ajay Mahato
- Frontend Developer: Ranjay Bose
- Integration Developer: Mohammed Tahir Madni
- Scrum master: Nishit Raj

## Weekly Meeting
Saturday 2PM to 3PM in person







