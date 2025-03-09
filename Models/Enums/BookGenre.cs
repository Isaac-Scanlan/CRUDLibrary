namespace CRUDLibrary.Models.Enums;

/// <summary>
/// Represents the types of genres that can be used to sort a book.
/// </summary>
public enum BookGenre
{
    /// <summary>
    /// Fiction genre.
    /// </summary>
    Fiction,

    /// <summary>
    /// Non-fiction genre.
    /// </summary>
    NonFiction,

    /// <summary>
    /// Books for Children.
    /// </summary>
    Children,

    /// <summary>
    /// Books with artwork integrated into the story-telling like comic books, and manga.
    /// </summary>
    GraphicNovel,

    /// <summary>
    /// Books that provide guidance, recommendations, or insights to help individuals improve their lives.
    /// </summary>
    Advice,

    /// <summary>
    /// Books that focus on economics, entrepreneurship, leadership, or corporate strategies.
    /// </summary>
    Business,

    /// <summary>
    /// Books related to health, exercise, and physical well-being.
    /// </summary>
    Fitness,

    /// <summary>
    /// Books that explore scientific discoveries, theories, or research across various disciplines.
    /// </summary>
    Science,

    /// <summary>
    /// Books about travel experiences, exploration, and cultural insights from different parts of the world.
    /// </summary>
    Travel,

    /// <summary>
    /// Fictional works that contain magical, supernatural, or otherworldly elements.
    /// </summary>
    Fantasy,

    /// <summary>
    /// Books set in futuristic or alternative societies, often depicting oppression, totalitarian regimes, or apocalyptic events.
    /// </summary>
    Dystopian,

    /// <summary>
    /// Books that are well-regarded literary works, often with historical significance or lasting influence.
    /// </summary>
    Classic,

    /// <summary>
    /// Books that focus on love, relationships, and emotional connections between characters.
    /// </summary>
    Romance,

    /// <summary>
    /// Books that center around exciting journeys, explorations, and risky undertakings.
    /// </summary>
    Adventure,

    /// <summary>
    /// Books that take place in a historical setting and incorporate real or fictional events from the past.
    /// </summary>
    Historical,

    /// <summary>
    /// Books characterized by dark, mysterious, and supernatural themes, often featuring eerie settings.
    /// </summary>
    Gothic,

    /// <summary>
    /// Books filled with suspense, tension, and high-stakes situations that keep readers engaged.
    /// </summary>
    Thriller,

    /// <summary>
    /// Books that aim to evoke fear, shock, or terror, often featuring supernatural or psychological elements.
    /// </summary>
    Horror,

    /// <summary>
    /// Other undefined genres
    /// </summary>
    Other = 999
}
