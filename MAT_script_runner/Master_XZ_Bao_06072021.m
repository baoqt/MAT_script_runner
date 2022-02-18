clc;
clear all;
close all;

TaskTitle = 'Block';
SubjectNum = 0;
TrialNum = 0;
path = 'C:\Users\baoqt\OneDrive\Documents -  OneDrive\MAT_Script_Runner\';

outcome = SensorKinematicsE_block_auto(strcat(path, 'Input\'),strcat(path, 'Output\'), TaskTitle, SubjectNum, TrialNum, 0, 0, 1, 0, 0, 1);