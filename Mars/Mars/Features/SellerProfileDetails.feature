Feature: SellerProfileDetails

A seller is able to update personal details like Name,Availibilty and Hours

#Background:
#   Given I logged into skillswap successfully

#   Scenario Outline: Add Description
#         When User add '<description>'
#		 Then Description added successfully
#
#		 Examples: 
#		 | description                                                                     |
#		 | Master of Computer Science with distinction.Proficiency in Specflow,Selenium,C# |
#
#@ignore
#Scenario Outline: Edit Description
#         When User edit '<description>'
#		 Then Description edited successfully
#
#
#@ignore
#Scenario Outline:Delete Description 
#         When User edit blank '<description>'
#		 Then User is prompted with message that a description required
#
#		 Examples: 
#		 | description |
#		 |             |
  

#Scenario Outline: Edit the First Name and Last Name 
#         When User update '<firstname>' and '<lastname>'
#		 Then User update First Name and Last Name successfully
#
#		 Examples: 
#		 | firstname | lastname |
#		 | Rimpal    | Sharma   |

#Scenario Outline:First Name and Last Name Mandatory
#         when User try to update first and last name with null
#         Then User prompted with message that First Name and Last Name are required

#@ignore
#Scenario: Update Blank First Name and Last Name
#         When user update  firstname and lastname
#		 Then User is prompted with a message that First Name and Last Name is required

#@ignore
#Scenario: Edit Availability
#         When user update availability
#		 Then Availability will be updated successfully and user prompted with message that availability updated

#@ignore
#Scenario: Edit the Hours
#         When user  update hours
#		 Then Hours updated successfully and user prompted with message that availability updated

#@ignore
#Scenario: Edit Earn Target
#         When user update earn target
#		 Then Earn target updated successfully and prompted with message

#@ignore
#Scenario: Edit Profile Picture
#         When user update profile picture
#		 Then profile picture updated successfully

#@ignore
#Scenario: Maximum 600 character allowed in Description
#         When user enter 601 character
#		 Then User can not enter more than 600 character

#Scenario:Blank Description
#        when user try to enter null
#        Then User prompted with message that Description required