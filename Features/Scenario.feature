Feature: Test Orangehrm 

@tag1
Scenario: Add and delete a work shift
    Given we have logged in the site
    When we go to the Work Shifts page
    And we add new work shift
    Then we have new time shift 
    When we delete new work shift row
    Then we have work shift row removed