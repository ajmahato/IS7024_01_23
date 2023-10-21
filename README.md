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
![MicrosoftTeams-image (7)](https://github.com/ajmahato/IS7024_01_23/assets/143025251/89a27208-aec6-4b50-922d-417d26bab4a5)

## Data Feeds
***
[National Park Service](https://www.nps.gov/subjects/developer/api-documentation.htm#/campgrounds/getCampgrounds)  
[Google places](https://developers.google.com/maps/documentation/places/web-service)  

## Functional Requirements

### Requirement 100.0 : Look up a hiking trail

**Scenario**

As a user, I want to get a list of hiking spots located near me.

**Dependencies**

Hiking spot data is available along with the address.

**Assumptions**

a) API might not cover all possible geographical locations

b) API providing hiking spot data will be available and reliable.

c) User will have to manually enter their city/state if application is not able to access user location.

**Example**

**1.1**

**Given** a list of possible hiking spots is available

**When** I select “Cincinnati Nature Center”

**Then** I should be directed to a page that gives me a brief overview of Cincinnati Nature Center. Some of the points to be covered in the overview are

- Address 
-	Weather
-	Pictures of the location
-	Popular trails covered by visitors.
-	Possible accommodation


### Requirement 101.0: Look up the weather at a hiking spot

**Scenario**

As a user, I want to weather related information about a hiking spot that I’m planning to visit.

**Dependencies**

Weather data is available via the weather API

**Assumptions**

API will provide the current weather weather forecast and also inform the use if it’s safe to travel to the selected location.

**Example**

**1.1**

**Given** I’ve selected Cincinnati Nature Center, along with the overview I’ll also get an option to check out the weather at that location.

**When** I choose to check out the weather

**Then** I should get the current climatic conditions which include the points

a)    	Whether or not its raining heavily

b)    	Whether its too hot to hike at the spot

c)    	The best time of the year to visit



## Scrum Roles
***
- Backend Developer/ product Owner: Ajay Mahato
- Frontend Developer: Ranjay Bose
- Integration Developer: Mohammed Tahir Madni
- Scrum master: Nishit Raj

## Weekly Meeting
Saturday 2PM to 3PM in person







