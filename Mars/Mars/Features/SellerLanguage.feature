Feature: SellerLanguage

 User is able to add ,update and delete language

Background: Login to website

 Given :User login to website

@tag1
Scenario Outline: Add new Language
        When User add a  '<language>' and '<languagelevel>'
		Then User language is added successfully on the user profile

		Examples: 
		| language | languagelevel  |
		| English  | Conversational |
		| Gujarati | Fluent         |
		| Hindi    | Basic          |


Scenario Outline: Edit Language
        When User update  a '<language>' to '<Editlanguage>' and '<Editlanguagelevel>'
		Then The language is updated successfully on the user profile

		Examples: 
		| language | Editlanguage | Editlanguagelevel |
		| Gujarati | French       | Basic             |
		| Hindi    | Kiwi         | Fluent            |

Scenario Outline:Remove Language
        When User delete a '<language>'
		Then The language is deleted successfully

		Examples: 
		| language |
		| French  |

#@ignore
#Scenario: Update cancel Language
#         When user cancel updating  language
#		 Then User cancel updating language successfully

#@ignore
#Scenario: maximum four language
#         When user try to add fifth language
#		 Then The language is not added to the user profile and a message is displayed to the user saying only a maximum of 4 user languages are allowed

