﻿namespace MemberClub.DAL.Entities;

public class User
{
    public long Id { get; set; }
    
    public string Name { get; set; }
    
    public string Email { get; set; }
    
    public DateTime RegistrationDate { get; set; }
}