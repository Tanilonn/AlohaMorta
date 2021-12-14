public class StoryTree
{
    private StoryNode root;

    public StoryTree(StoryNode root)
    {
        this.root = root;
    }

    public bool Contains(StoryNode node)
    {
        if(node.parent == node)
        {
            return true;
        }
        else
        {
            return Contains(node.parent);
        }
    }



}

