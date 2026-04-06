using System.Text.Json.Serialization;

namespace Rocket.Unsplash.Enums;

public static class EnumExtensions
{
    public static string ToApiString(this Orientation orientation) => orientation switch
    {
        Orientation.Landscape => "landscape",
        Orientation.Portrait => "portrait",
        Orientation.Squarish => "squarish",
        _ => throw new ArgumentOutOfRangeException(nameof(orientation))
    };

    public static string ToApiString(this ContentFilter filter) => filter switch
    {
        ContentFilter.Low => "low",
        ContentFilter.High => "high",
        _ => throw new ArgumentOutOfRangeException(nameof(filter))
    };

    public static string ToApiString(this PhotosOrderBy orderBy) => orderBy switch
    {
        PhotosOrderBy.Latest => "latest",
        PhotosOrderBy.Oldest => "oldest",
        PhotosOrderBy.Popular => "popular",
        PhotosOrderBy.Views => "views",
        PhotosOrderBy.Downloads => "downloads",
        _ => throw new ArgumentOutOfRangeException(nameof(orderBy))
    };

    public static string ToApiString(this SearchPhotosOrderBy orderBy) => orderBy switch
    {
        SearchPhotosOrderBy.Relevant => "relevant",
        SearchPhotosOrderBy.Latest => "latest",
        _ => throw new ArgumentOutOfRangeException(nameof(orderBy))
    };

    public static string ToApiString(this TopicsOrderBy orderBy) => orderBy switch
    {
        TopicsOrderBy.Featured => "featured",
        TopicsOrderBy.Latest => "latest",
        TopicsOrderBy.Oldest => "oldest",
        TopicsOrderBy.Position => "position",
        _ => throw new ArgumentOutOfRangeException(nameof(orderBy))
    };

    public static string ToApiString(this TopicPhotosOrderBy orderBy) => orderBy switch
    {
        TopicPhotosOrderBy.Latest => "latest",
        TopicPhotosOrderBy.Oldest => "oldest",
        TopicPhotosOrderBy.Popular => "popular",
        _ => throw new ArgumentOutOfRangeException(nameof(orderBy))
    };
}
