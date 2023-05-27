Feature: SellerCertifications

A Seller can add,update,delete certifications
Background:
  Given I logged into skillswap successfully

   

Scenario Outline:Add Certification
         When user add a '<certificate>' and '<certificatefrom>','<certificateyear>'
		 Then User add certification successfully

		 Examples: 
		 | certificate  | certificatefrom  | certificateyear |
		 | Test Analyst | Industry connect | 2022            |


#@ignore
#Scenario: Edit Certification
#         When user update certification
#		 Then Certification edited successfully

#@ignore
#Scenario:All fiellds are mandatory 
#         When user update blank certification
#		 Then User is prompted with a message that enter certification name,certification from and certification year

#@ignore
#Scenario:Cancel updating Certification
#         When user cancel updating  certification
#		 Then User cancel updating certification successfully

#Scenario:Update duplicate Certification
#         When user try to update duplicate certification
#		 Then User is prompted with a message that information is already exist

#Scenario:Delete Certification
#       when user try to delete <certificate>
#       Then Certification deleted successfully
