using NUnit.Framework;

namespace App.Puzzles.Year2020.Day02
{
    public class Year2020Day02Tests
    {
        [TestCase("1-3 a: abcde")]
        [TestCase("2-9 c: ccccccccc")]
        public void PasswordIsValidAccordingToRuleOne(string policy)
        {
            var policyValidator = new PasswordPolicyValidator();
            var result = policyValidator.IsValidAccordingToRuleOne(policy);

            Assert.That(result, Is.True);
        }

        [TestCase("1-3 b: cdefg")]
        public void PasswordIsInvalidAccordingToRuleOne(string policy)
        {
            var policyValidator = new PasswordPolicyValidator();
            var result = policyValidator.IsValidAccordingToRuleOne(policy);

            Assert.That(result, Is.False);
        }

        [TestCase("1-3 a: abcde")]
        public void PasswordIsValidAccordingToRuleTwo(string policy)
        {
            var policyValidator = new PasswordPolicyValidator();
            var result = policyValidator.IsValidAccordingToRuleTwo(policy);

            Assert.That(result, Is.True);
        }

        [TestCase("1-3 b: cdefg")]
        [TestCase("2-9 c: ccccccccc")]
        public void PasswordIsInvalidAccordingToRuleTwo(string policy)
        {
            var policyValidator = new PasswordPolicyValidator();
            var result = policyValidator.IsValidAccordingToRuleTwo(policy);

            Assert.That(result, Is.False);
        }

    }
}