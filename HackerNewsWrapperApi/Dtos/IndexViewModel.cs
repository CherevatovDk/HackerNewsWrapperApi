namespace HackerNewsWrapperApi.Dtos;

public class IndexViewModel
{
        public PageViewModel PageViewModel { get; }
        public IEnumerable<StoryDto> Story { get; }

        public IndexViewModel(PageViewModel pageViewModel, IEnumerable<StoryDto> story)
        {
                PageViewModel = pageViewModel;
                Story = story;
        }
}