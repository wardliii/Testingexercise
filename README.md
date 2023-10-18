# Hangman

## To Correctly Reload Project WITH TESTING WORKING

1. Checkout branch.
2. See that "HangmanTesting" project does not load/is not found in solution explorer.
3. Right click "HangmanTesting" project in solution explorer and select "Remove".
4. Right click on "Solution 'Hangman'" in solution explorer and select "Add > Existing Project"
5. Navigate to repo on local hard disk and select "Hangman\HangmanTesting\HangmanTesting.csproj"
6. See that HangmanTesting project now loads.
7. In solution explorer, under the HangmanTesting project open Dependencies, right click on "Packages" and select "Update..." then select all available updates and apply them.
8. In solution explorer's top bar, select "Show All Files" to see hidden files in the solution.
9. Right click on the folder titled "HangmanTesting" under the Hangman project, select "Exclude From Project".


You can now open test explorer and use the build & run all tests to run the existing tests.

# IMPORTANT
## BEFORE YOU MAKE A COMMIT & PUSH TO YOUR BRANCH

Before you make a commit and push to your branch you **MUST** perform steps 8 and 9 again to re-include the testing folder into the project or github loses its mind and either doesn't upload them, or doesn't download them again.

## THE ABOVE IS VERY IMPORTANT OR YOUR TESTING CHANGES WILL BE LOST!!

