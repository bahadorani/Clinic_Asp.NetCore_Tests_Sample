﻿using Clinic.Api;
using Clinic.Domain.Dtoes;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow.Assist;

namespace Client.AcceptanceTest.Drivers
{
    public class ClinicDriver
    {
        private readonly HttpClient _httpClient;
        public readonly ClinicContext SenarioContext;

        public ClinicDriver(WebApplicationFactory<Program> factory)
        {
            _httpClient = factory.CreateClient();
            SenarioContext = new ClinicContext();
        }

        public void SetClinicInfo(Table table)
        {
            SenarioContext.CenterContext = table.CreateInstance<CenterDto>();
        }

        public void SetUserInfo(Table table)
        {
            SenarioContext.UserContext = table.CreateInstance<UserDto>();
        }

        public void SetExpertInfo(Table table)
        {
            SenarioContext.ExpertContext = table.CreateInstance<ExpertDto>();
        }

        public void SetInfo(Table table)
        {
            var customers = table.CreateInstance<BillDto>();
            SenarioContext.BillContext = customers;
        }

        internal void SetInsuranceInfo(Table table)
        {
            SenarioContext.InsuranceContext = table.CreateInstance<InsuranceDto>();
        }

        public async Task<decimal?> CountInsurancePayments(int id)
        {
            HttpResponseMessage result = await _httpClient.GetAsync(Routes.GetPaymentOfInsuredById + "?id=" + id);
            ClinicResponse response = await result.DeserializeAsync<ClinicResponse>();

            if (response.Success )
            {
                return response.Data.InstallmentPay;
            }
            else
            {
                return 0;
            }
        }

        internal void SetDoctorInfo(Table table)
        {
            SenarioContext.DoctorContext = table.CreateInstance<DoctorDto>();
        }

        internal void SetVisitInfo(Table table)
        {
            SenarioContext.VisitContext = table.CreateInstance<VisitDto>();
        }

        internal void SetPatientInfo(Table table)
        {
            SenarioContext.PatientContext = table.CreateInstance<PatientDto>();
        }

        internal void SetBillInfo(Table table)
        {
            SenarioContext.BillContext = table.CreateInstance<BillDto>();
        }

        internal async Task<int> CountInstallmentWithPatientId(int id)
        {
            HttpResponseMessage result = await _httpClient.GetAsync(Routes.GetLiabilityPatientById + "?id=" + id);
            ClinicResponse response = await result.DeserializeAsync<ClinicResponse>();

            if (response.Success)
            {
                return response.Data.InstallmentCount;
            }
            else
            {
                return 0;
            }
        } 
    }
}
