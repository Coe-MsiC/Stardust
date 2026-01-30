using osu.Framework.Testing;

namespace stardust.Game.Tests.Visual
{
    public abstract partial class stardustTestScene : TestScene
    {
        protected override ITestSceneTestRunner CreateRunner() => new stardustTestSceneTestRunner();

        private partial class stardustTestSceneTestRunner : stardustGameBase, ITestSceneTestRunner
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
