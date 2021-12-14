using System.Collections.Generic;

public static class Story
{
    public static StoryNode introduction = new StoryNode(null);
    public static StoryTree storyline = new StoryTree(introduction);

    public static StoryNode currentNode;

    public static List<Branch> Branches { get; set; } = new List<Branch>();
    public static Branch CurrentBranch { get; set; }


}

