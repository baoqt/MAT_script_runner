clc;
clear;
close all;

viconsecondpeak = -1;
imusecondpeak = -1;

viconthirdpeak = -1;
imuthirdpeak = -1;


task = 'Block';
inputPath       = '..\..\Data\Input\IMU\Block\';
outputPath      = '..\..\Data\Output\IMU\Block\';
viconPath       = '..\..\Data\Input\Vicon\Block\';
viconOutputPath = '..\..\Data\Output\Vicon\Block\';
viconFilename   = 'Block';

participant = 1;
trial = 1;
startTrial = trial;
endTrial = 1;

result = zeros(1, 12);

% Resultant velocity processing scripts
sensorMode = 1;
viconMode = 1;
plotMode = 0;

% Requires sensorMode and viconMode to be true
velocityMode = 1;
velocityPlotMode = 1;

% Requires sensorMode, viconMode, and velocityMode to be true
outcomeMode = 1;


for startTrial = startTrial:endTrial
    if (sensorMode)
        SensorKinematicsE_block_auto(inputPath, outputPath, task, participant, startTrial, 0, 0, plotMode, 0, 0, 0);
    end
    if (viconMode)
        TenaSensor2_BlockTask_ViconData_auto(viconPath, viconOutputPath, viconFilename, startTrial, plotMode);
    end
    
    if (velocityMode && sensorMode && viconMode)
        try
        vicon = readmatrix(strcat(path, 'Output\', task, '\Velocity_', int2str(participant), '_', int2str(startTrial), '.csv'));  
        imu = readmatrix(strcat(viconPath, 'Output\', task, '\Velocity_', viconFilename, sprintf("_%02d", startTrial), '.csv'));  

        imu = imu/10;

        %Movement Time
        viconmt = length (vicon)*10;
        imumt = length (imu)*10;
        
        %Path Length
        viconpl = trapz(vicon);
        imupl = trapz(imu);
        
        %Ratio
        viconmean = mean(vicon);
        viconmax = max(vicon);
        viconratio = (viconmean/viconmax);
        
        imumean = mean(imu);
        imumax = max(imu);
        imuratio = (imumean/imumax);
        
        
        %%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
        %Clip length of vectors to the minimum
        vicon = (vicon(1:min(viconmt/10, imumt/10)));
        imu = imu(1:min(viconmt/10, imumt/10));
        
        correlation = corrcoef(vicon, imu);
        correlation = correlation(1,2);

        covariance = cov(vicon, imu);
        covariance = covariance(1,2);
        
        RMSE = sqrt(mean((vicon - imu).^2));
        
        mse = immse (vicon, imu);
        
        %%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%



        
        if (velocityPlotMode)
            figure(2)
            plot (vicon); hold on; plot (imu);
        end

        [maxtab_vicon, mintab_vicon] = peakdet(vicon, .2);
        [maxtab_imu, mintab_imu] = peakdet(imu, .2);
        
        try
        viconsecondpeak = maxtab_vicon(2,2);
        imusecondpeak = maxtab_imu(2,2);
          
        viconthirdpeak = maxtab_vicon(3,2);
        imuthirdpeak = maxtab_imu(3,2);
        catch
            disp(strcat(strcat('Trial ', startTrial, ": Peak error, missing second or third peak.")));
        end
  
        
        %%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%% Time Normalized and then examine
        %%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%% similarity between signals
        viconnorm = intrp100(vicon);
        imunorm = intrp100(imu);
        
        corrnorm = corrcoef(vicon, imu);
        corrnorm = correlation(1,2);

        covnorm = cov(vicon, imu);
        covnorm = covariance(1,2);
        
        RMSEnorm = sqrt(mean((vicon - imu).^2));
        
        msenorm = immse (vicon, imu);
        
        
        outcome = [correlation, corrnorm, covariance, covnorm, RMSE, RMSEnorm, mse, msenorm, viconpl, imupl, viconmt, imumt, viconsecondpeak, imusecondpeak, viconthirdpeak, imuthirdpeak];
        result = [result; outcome];
        catch
            %disp(strcat(strcat('Trial ', int2str(startTrial), ": Missing velocity file.")));
        end

    end
end

if (outcomeMode && sensorMode && viconMode && velocityMode)
    writematrix(result, strcat(outputPath, '\Result_', task, '_', int2str(participant), '_', int2str(trial), '-', int2str(endTrial), '.csv'));
end
% 5, 24
