using System;
using API.DTOs;
using API.Entities;
using API.Interfaces;

namespace API.Extentions;

//Extention Methods
public static class AppUserExtentions
{
    public static async Task<UserDto> ToDto(this AppUser user, // extending AppUser class with a method to convert it to UserDto
    ITokenService tokenService) //Cannot do dependency injection in static class.so we have to pass the TokenService as parameter
    {
        var userDto = new UserDto
        {
            Id = user.Id,
            DisplayName = user.DisplayName,
            Email = user.Email!,
            ImageUrl = user.ImageUrl,
            Token = await tokenService.CreateToken(user)
        };
        return userDto;

    }
}
