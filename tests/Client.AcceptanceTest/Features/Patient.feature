Feature: Patient

Background:
	Given clinic info with below data
		| Id | Title          | Address     |
		| 1  | CenteralClinic | ----------- |
	And Users infos with below data
		| Id | Name  | Family | Tell        | CenterId |
		| 2  | Ali   | Zamani | 09132000000 | 1        |
		| 3  | Zahra | Omodi  | 09148000000 | 1        |
	And Experts of doctors with bellow data
		| Id | Title        |
		| 4  | Neurologists |
		| 5  | Nephrologist |
	And Insurance info with below data
		| Id | IdentityNumber | Title | Tell        | Address |
		| 4  | 123456789      | Asia  | 09178200336 | ------  |



Scenario: Check installment count for each patient
	When a patient that is not covered by health insurance with the below data goes to the clinic for treatment
		| Id | UserId | IdentityCart | InsuranceId | Caption  |
		| 1  | 2      | 1472583690   | null        | -------- |
	And a doctor with the following profile is visiting the patients.
		| Id | UserId | ExpertId |
		| 1  | 3      | 5        |
	And the patient and the doctor have an appointment together and the patient will pay the treatment fee in installments with the below data
		| Id | DoctorId | PatientId | Price   | Caption  | InstallmentCount | InstallmentPay | Date                |
		| 6  | 3        | 2         | 1000000 | -------- | 2                | 50000          | 2023-02-14 18:08:06 |
	When the patient pay money of treatment according to visit info in bellow data
		| Id | VisitId | Payment | Date                |
		| 1  | 6       | 50000   | 2023-02-20 10:08:06 |
	Then the result of installment that the patient "2" has not paid is "1" installment.


	





