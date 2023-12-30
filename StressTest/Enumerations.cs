namespace StressTest
{
    /// <summary>
    /// Enumeration of girder material types
    /// </summary>
    public enum Material
    {
        StainlessSteel,
        Aluminum,
        ReinforcedConcrete,
        Composite,
        Titanium
    }
    /// <summary>
    /// Enumeration of girder cross-sections
    /// </summary>
    public enum CrossSection
    {
        IBeam,
        Box,
        ZShaped,
        CShaped
    }
    /// <summary>
    /// Enumeration of test results
    /// </summary>
    public enum TestResult
    {
        Pass=1,
        Fail=0
    }

    public struct TestCaseResult
    {
        /// <summary>
        /// Test result (enumeration type)
        /// </summary>
        public TestResult Result;
        /// <summary>
        /// Description of reason for failure
        /// </summary>
        public string ReasonForFailure;

        public TestCaseResult(TestResult Result, string ReasonForFailure)
        {
            this.Result = Result;
            this.ReasonForFailure = ReasonForFailure;
        }
    }
}