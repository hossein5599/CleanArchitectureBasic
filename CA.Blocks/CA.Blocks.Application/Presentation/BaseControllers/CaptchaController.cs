using CA.Blocks.Application.Common.ExtentionMethods;
using CA.Blocks.Application.Common.Features;
using CA.Blocks.Application.Presentation.Configurations;
using CaptchaGen.NetCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Swashbuckle.AspNetCore.Annotations;

namespace CA.Blocks.Application.Presentation.BaseControllers;

[SwaggerTag("Captcha service")]
public partial class CaptchaController(IMemoryCache memoryCache) : BaseController
{
    [HttpGet]
    [SwaggerOperation("Generate captcha")]
    public IActionResult Generate()
    {
        string captchaCode;
        string encryptedCaptchaCode;
        do
        {
            captchaCode = ImageFactory.CreateCode(CaptchaSettings.DigitCount);
            encryptedCaptchaCode = EncryptionHelper.Encrypt(captchaCode);
        }
        while (encryptedCaptchaCode.Contains('/') || encryptedCaptchaCode.Contains('+'));

        var cacheEntryOptions = new MemoryCacheEntryOptions()
        {
            AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(2)
        };
        memoryCache.Set(encryptedCaptchaCode, captchaCode, cacheEntryOptions);

        var result = new Result<string>();
        result.AddValue(encryptedCaptchaCode);
        result.OK();

        return ApiResult(result);
    }

    [HttpGet("{encryptedCaptchaCode}")]
    [SwaggerOperation("Get Captcha Image")]
    public IActionResult GetImage(string encryptedCaptchaCode)
    {
        var captchaCode = EncryptionHelper.Decrypt(encryptedCaptchaCode);
        using var captchaImage = ImageFactory.BuildImage(
            captchaCode,
            CaptchaSettings.Height,
            CaptchaSettings.Width,
            CaptchaSettings.FontSize,
            CaptchaSettings.Distortion
            );

        return File(captchaImage.ToArray(), "image/jpg");
    }
}