using osu.Framework.Testing;

namespace of_example_project.Game.Tests.Visual
{
    public abstract partial class of_example_projectTestScene : TestScene
    {
        protected override ITestSceneTestRunner CreateRunner() => new of_example_projectTestSceneTestRunner();

        private partial class of_example_projectTestSceneTestRunner : of_example_projectGameBase, ITestSceneTestRunner
        {
            private TestSceneTestRunner.TestRunner runner;

            protected override void LoadAsyncComplete()
            {
                base.LoadAsyncComplete();
                Add(runner = new TestSceneTestRunner.TestRunner());
            }

            public void RunTestBlocking(TestScene test) => runner.RunTestBlocking(test);
        }
    }
}
