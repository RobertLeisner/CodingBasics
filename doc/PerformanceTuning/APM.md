App performance measuring (APM)
==============

# APM at dev time




# APM at runtime: employing EventCounters for APM

## Types of event counters

MS implements four types of event counters

-	**EventCounter**: use it if you want to get metrics like mean, min, max etc. for time period etc.

-	**IncrementingEventCounter**: counts the total number of times a certain events has happened

-	**PollingCounter**:

-	**IncrementingPollingCounter**:

If MS talks about event counters it means potentially all 4 types of event counters 

There is no common interface for the four types of event counters defined by MS. 

Event counters are platform independent.

## EventCounter class

Use this type of event counter if you want to get metrics like mean, min, max etc. for time period etc. out of an app.

Example: 

-	method runtime in milliseconds

## IncrementingEventCounter class

Use this type of event counter if you want count the total number of times a certain events has happened.

Example: 

-	Total number a certain method was called

-	Total number of messages sent to a device
