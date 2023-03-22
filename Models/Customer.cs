using System;
using System.Collections.Generic;

namespace AcademiaBromus.Models;

public partial class Customer
{
    public string CustomerId { get; set; } = null!;

    public string CompanyName { get; set; } = null!;

    public string? ContactName { get; set; }

    public string? ContactTitle { get; set; }

    public string? Address { get; set; }

    public string? City { get; set; }

    public string? Region { get; set; }

    public string? PostalCode { get; set; }

    public string? Country { get; set; }

    public string? Phone { get; set; }

    public string? Fax { get; set; }
}
/*
 * [
{ "customerId": "ANATO",
    "companyName": "Ana Consultorio",
    "contactName": "Ana Rodriguez",
    "contactTitle": "Dueño",
    "address": "Avda. de la Constitución 15562",
    "city": "Tecka",
    "region": null,
    "postalCode": "9500",
    "country": "Argentina",
    "phone": "(2945) 45-6892",
    "fax": "(2945) 45-6893"
}
*/