using Microsoft.EntityFrameworkCore;
using System;
using TaskPomodoro.API.Data;
using AutoMapper;
using TaskPomodoro.API.Profiles;
using FluentValidation;
using FluentValidation.AspNetCore;
using TaskPomodoro.API.DTOs;
using TaskPomodoro.API.Validations;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddControllers().AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<TarefaCreateValidator>());
builder.Services.AddAutoMapper(typeof(TarefaProfile), typeof(SessaoPomodroProfile)); // Adiciona o AutoMapper e registra o perfil
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
