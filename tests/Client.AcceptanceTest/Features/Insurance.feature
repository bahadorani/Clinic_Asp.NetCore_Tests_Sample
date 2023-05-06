Feature: Insurance

Background:
	Given the patients with below data
		| Id | UserId | IdentityCart | InsuranceId | Caption  |
		| 1  | 2      | 1472583690   | 4           | -------- |
		| 1  | 3      | 1586683690   | 4           | -------- |

Scenario: Total payments for medical expenses of an insurance company
	Given a insurance company with below data
		| Id | IdentityNumber | Title | Tell        | Address |
		| 4  | 123456789      | Asia  | 09178200336 | ------  |
	When This insurance company pays for the treatment of patients under its coverage according to the following information
		| Id | VisitId | Payment | Date                |
		| 1  | 6       | 50000   | 2023-01-20 10:08:06 |
		| 2  | 7       | 100000  | 2023-04-13 10:08:06 |
		| 3  | 8       | 70000   | 2023-03-05 10:08:06 |
	Then the result of The total amount paid by company "4" for covered patients is "220000" Tomans.
