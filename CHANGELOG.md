# Changelog
All notable changes to this project will be documented in this file.

## [Unreleased]

## [1.1.0] - 2020-05-29
### Changes
- Version format is now MAJOR.MINOR.PATCH which will correspond to Visual Studio version MAJOR.MINOR.0.REVISION where 0 will always be the unneeded Build number.
- Refactored code to use SystemInformation.VirtualScreen instead of method GetLogicalScreenBounds().
- Refactored code for window resizing actions.
- Fix bug: Do not allow resizing to width or height less than 10.

