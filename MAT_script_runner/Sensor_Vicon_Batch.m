clc;
clear;
close all;

viconPlacePeak = -1;
imuPlacePeak = -1;

viconReturnPeak = -1;
imuReturnPeak = -1;


task = 'Block';
inputPath       = '..\..\Data\Input\IMU\Block\';
outputPath      = '..\..\Data\Output\IMU\Block\';
viconPath       = '..\..\Data\Input\Vicon\Block\';
viconOutputPath = '..\..\Data\Output\Vicon\Block\';
viconFilename   = 'Block2';

participant = 2;
trial = 1;
startTrial = trial;
endTrial = 300;


% Output headers here
result = ["Trial", "correlation", "corrnorm", "covariance", "covnorm", "RMSE", "RMSEnorm", "mse", "msenorm", "viconpl", "imupl", "viconmt", "imumt", "viconplacepeak", "imuplacepeak", "viconreturnpeak", "imureturnpeak"];
errors = ["Trial", "Error text"];

% Resultant velocity processing scripts
sensorMode = 1;
viconMode = 1;
plotMode = 0; % where 1 = plot on

% Requires sensorMode and viconMode to be true
velocityMode = 1;
velocityPlotMode = 0;

% Requires sensorMode, viconMode, and velocityMode to be true
outcomeMode = 1; %if outcomeMode = 0, then it won't save a csv


for startTrial = startTrial:endTrial
    if (sensorMode)
        sensorError = SensorKinematicsE_block_auto(inputPath, outputPath, task, participant, startTrial, 0, 0, plotMode, 0, 0, 0);
    
        if (sensorError(1,1) ~= "-1")
            errors = vertcat(errors, sensorError);
        end
    end
    if (viconMode)
        TenaSensor2_BlockTask_ViconData_auto(viconPath, viconOutputPath, viconFilename, startTrial, plotMode);
    end
    
    if (velocityMode && sensorMode && viconMode)
        try
            vicon = readmatrix(strcat(viconOutputPath, 'Velocity_', viconFilename, '_', sprintf("%03d", startTrial), '.csv'));  
            imu = readmatrix(strcat(outputPath, 'Velocity_', int2str(participant), '_', int2str(startTrial), '.csv'));  
        catch
            errorText = strcat("Trial ", int2str(startTrial), ": Missing velocity file.");
            disp(errorText);

            errorEntry = [int2str(startTrial), errorText];
            errors = vertcat(errors, errorEntry);
        end
        
        imu = imu*10;

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
            imuMaxes = maxk(maxtab_imu(:, 2), 2);
            viconMaxes = maxk(maxtab_vicon(:, 2), 2);

            imuMax1 = find(maxtab_imu == imuMaxes(1));
            imuMax2 = find(maxtab_imu == imuMaxes(2));
            viconMax1 = find(maxtab_vicon == viconMaxes(1));
            viconMax2 = find(maxtab_vicon == viconMaxes(2));

            imuPlaceIndex = min(imuMax1, imuMax2);
            imuReturnIndex = max(imuMax1, imuMax2);
            viconPlaceIndex = min(viconMax1, viconMax2);
            viconReturnIndex = max(viconMax1, viconMax2);

            imuPlacePeak = maxtab_imu(imuPlaceIndex);
            imuReturnPeak = maxtab_imu(imuReturnIndex);
            viconPlacePeak = maxtab_vicon(viconPlaceIndex);
            viconReturnPeak = maxtab_vicon(viconReturnIndex);
        catch
            errorText = strcat("Trial ", int2str(startTrial), ": Peak error, missing peaks.");
            disp(errorText);

            errorEntry = [int2str(startTrial), errorText];
            errors = vertcat(errors, errorEntry);
        end
        
        %%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%% Time Normalized and then examine
        %%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%% similarity between signals
        viconnorm = intrp100(vicon);
        imunorm = intrp100(imu);
        
        corrnorm = corrcoef(viconnorm, imunorm);
        corrnorm = corrnorm(1,2);

        covnorm = cov(viconnorm, imunorm);
        covnorm = covnorm(1,2);
        
        RMSEnorm = sqrt(mean((viconnorm - imunorm).^2));
        
        msenorm = immse (viconnorm, imunorm);
        
        outcome = [startTrial, correlation, corrnorm, covariance, covnorm, RMSE, RMSEnorm, mse, msenorm, viconpl, imupl, viconmt, imumt, viconPlacePeak, imuPlacePeak, viconReturnPeak, imuReturnPeak];
        result = [result; outcome];
        

    end
end

if (outcomeMode && sensorMode && viconMode && velocityMode)
     writematrix(result, strcat(outputPath, '\Result_', task, '_', int2str(participant), '_', int2str(trial), '-', int2str(endTrial), '.csv'));
end

disp("Finished!");
