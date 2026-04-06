namespace Rocket.Unsplash.Requests;

public sealed record UpdatePhotoRequest
{
    public string? Description { get; init; }
    public bool? ShowOnProfile { get; init; }
    public string[]? Tags { get; init; }
    public double? LocationLatitude { get; init; }
    public double? LocationLongitude { get; init; }
    public string? LocationName { get; init; }
    public string? LocationCity { get; init; }
    public string? LocationCountry { get; init; }
    public string? ExifMake { get; init; }
    public string? ExifModel { get; init; }
    public string? ExifExposureTime { get; init; }
    public string? ExifApertureValue { get; init; }
    public string? ExifFocalLength { get; init; }
    public string? ExifIsoSpeedRatings { get; init; }
}
