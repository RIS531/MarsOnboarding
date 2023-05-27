Feature: SellerSkills

A seller is able to add ,update and delete skills

Background: Login to Tradeskill website

 Given :User login to TradeWebsite

Scenario Outline: Add new Skill
        When User add a '<skill>' and '<skilllevel>'
		Then User skill is added successfully on the user profile

		Examples: 
		| skill    | skilllevel     |
		| C        | Expert         |
		| Selenium | Intermediate   |
		| Vb       | Beginner       |

Scenario Outline: Edit Skills
        When User update a '<skill>' to '<updateskill>' and '<updateskilllevel>'
		Then The skill is updated successfully on the user profile

		Examples: 
		| skill    | updateskill | updateskilllevel |
		| Selenium | Cypress     | Expert           |
		| Vb       | Csharp      | Intermediate     |

Scenario Outline: Remove Skill
        When User delete a  '<skill>'
		Then The skill is deleted successfully on the user profile

       
	   Examples:   
	   | skill |
	   | C     |


#@ignore
#Scenario: Update Blank skill
#         When user update blank skill
#		 Then User is prompted with a message that enter skill and experience level
#@ignore
#Scenario: Update cancel Skill
#         When user cancel updating  skill
#		 Then User cancel updating skill successfully
