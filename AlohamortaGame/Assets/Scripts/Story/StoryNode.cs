public class StoryNode
{
    public StoryNode left;
    public StoryNode right;
    public StoryNode parent;

    public StoryNode(StoryNode parent)
    {
        this.parent = parent;
    }


}

