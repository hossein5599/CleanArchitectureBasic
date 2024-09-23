namespace CA.Blocks.Application.Common.Dtos;
public record CaptchaDTO(
    string? Code,
    string? EncryptedCode
    );