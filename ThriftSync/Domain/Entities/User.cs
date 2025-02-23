﻿using System.ComponentModel.DataAnnotations;

namespace ThriftSync.Domain.Entities;

public class User
{
    [Key]
    public Guid Id { get; set; }
    public string Email { get; set; }
    public string Username { get; set; }
    public string PasswordHash { get; set; }
    public DateTime LastLogin { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}