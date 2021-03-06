function [mean_vel, max_vel, sal, mtimu, path_length] = SensorKinematicsE_auto(InputPath, OutputPath, GestureName, SubjectNumInt, TrialNumInt, plot_mode, output_mode, manTrimLeft, manTrimRight, stationaryThreshold, kpStat, kpMove)

%% Import Libraries
addpath('Quaternions');

%% Assign defaults if specified in arguments
if stationaryThreshold <= 0                     
    stationaryThreshold = 0.0025;               
end


% AHRS kp values will need to be adjusted on a per gesture basis
switch GestureName
    case "Block"
        if kpStat == 0
            kpStat = 0;
        end

        if kpMove == 0
            kpMove = 2;     % 10
        end  
    case "Glass"
        if kpStat == 0
            kpStat = 0.5;
        end

        if kpMove == 0
            kpMove = 2;     % 10
        end
    case "Nose"
        if kpStat == 0
            kpStat = 0;
        end

        if kpMove == 0
            kpMove = 6;     % 10
        end
    otherwise
        if kpStat == 0
            kpStat = 0;
        end

        if kpMove == 0
            kpMove = 2;     % 10
        end  
end

outcome = ["-1", "-1"];
%% File Name Parameters:

SubjectNum = int2str(SubjectNumInt);

TrialNum = int2str(TrialNumInt);

%% IMU Data Entry (Paste Data or Read From File)
% Load IMU File
data = csvread(strcat(InputPath, '\', SubjectNum, '_', TrialNum, '.csv'), 0,0); % IMU file name will have one '_'
data = data(max([manTrimLeft 1]):(end-manTrimRight),:);

        %% Pre-Processing Filter
    
%         % LP filter all IMU data
        filtCutOff = 3;
        [b, a] = butter(1, (2*filtCutOff)/(1/0.01), 'low');
        data2 = filtfilt(b, a, data);

        %% Automatic Trimming of IMU
% Axes will need to be adjusted such that the axis at rest will have
% gravity constant removed from it. This depends on how the sensor lays
% while at stationary periods beginning and ending the gesture.
    g = 9.81;
    if (GestureName == "Nose")
        if (size(data, 2) == 6)
            axTemp = (data2(:, 1)/g);
            ayTemp = (data2(:,3)/g);
            azTemp = -(data2(:,2)/g+1);

            gyrXTemp = data2(:,4);
            gyrYTemp = data2(:,6);
            gyrZTemp = -data2(:,5);
        else
            axTemp = (data2(:,2)/g);
            ayTemp = (data2(:,4)/g);
            azTemp = -(data2(:,3)/g+1);

            gyrXTemp = data2(:,5);
            gyrYTemp = data2(:,7);
            gyrZTemp = -data2(:,6);
        end
    else
        if (size(data, 2) == 6)
            axTemp = (data2(:, 1)/g);
            ayTemp = (data2(:,3)/g);
            azTemp = -(data2(:,2)/g+1);

            gyrXTemp = data2(:,4);
            gyrYTemp = data2(:,6);
            gyrZTemp = -data2(:,5);
        else
            axTemp = (data2(:,2)/g);
            ayTemp = (data2(:,4)/g);
            azTemp = -(data2(:,3)/g+1);

            gyrXTemp = data2(:,5);
            gyrYTemp = data2(:,7);
            gyrZTemp = -data2(:,6);
        end
    end
    
    ac1_mag = sqrt((axTemp) .* (axTemp) + (ayTemp) .* (ayTemp) + (azTemp) .* (azTemp));
    trimTempL1 = max([1 min([find( azTemp<0.7, 1,'first') find(abs(gyrXTemp)>10,1,'first') find(abs(gyrYTemp)>10,1,'first') find(abs(gyrZTemp)>10,1,'first') find( abs(ac1_mag-1) > 0.1 , 1,'first')])  ]);
    trimLeft = max([1 find( abs(ac1_mag(1:trimTempL1)-1) < 0.025 , 1,'last')-100]);
    
    if abs(azTemp(1)) > abs(ayTemp(1))
        trimTemp1 = min([length(data2)  max( [find( azTemp<0.7, 1,'last') find(abs(gyrXTemp)>5,1,'last') find(abs(gyrYTemp)>5,1,'last') find(abs(gyrZTemp)>5,1,'last')])]);
    else
        trimTemp1 = min([length(data2)  max( [find( ayTemp<0.7, 1,'last') find(abs(gyrXTemp)>5,1,'last') find(abs(gyrYTemp)>5,1,'last') find(abs(gyrZTemp)>5,1,'last')])]);
    end
    trimTemp2 = min([find( abs(ac1_mag(trimTemp1:end)-1)>0.1,1,'last')+trimTemp1 length(data2)] );
    trimTemp3 = min([find( abs(ac1_mag(trimTemp2:end)-1)<0.02,1,'last')+trimTemp2 length(data2)] );
    trimRight = min([find( abs(ac1_mag((trimTemp2+100):trimTemp3)-1)<0.0025,1,'last')+trimTemp2 length(data2)]);
    
    data = data(trimLeft:trimRight,:);
    data2 = data2(trimLeft:trimRight,:);
    
    gyrXTemp = gyrXTemp(trimLeft:trimRight,:);
    gyrYTemp = gyrYTemp(trimLeft:trimRight,:);
    gyrZTemp = gyrZTemp(trimLeft:trimRight,:);

    %% IMU Data pre-processing on Import
    samplePeriod = 1/100;
    
    g = 9.81;
    % Axes reorientation and gravity constant removal
    if (GestureName == "Nose")
        if (size(data, 2) == 6)
            accX = data(:,1)/g;
            accY = data(:,3)/g;
            accZ = -data(:,2)/g+1;

            gyrX = data(:,4);
            gyrY = data(:,6);
            gyrZ = -data(:,5);
        else
            accX = data(:,2)/g;
            accY = data(:,4)/g;
            accZ = -data(:,3)/g+1;

            gyrX = data(:,5);
            gyrY = data(:,7);
            gyrZ = -data(:,6);
        end
    
    else
        if (size(data, 2) == 6)
            accX = data(:,1)/g;
            accY = data(:,2)/g;
            accZ = data(:,3)/g+1;

            gyrX = data(:,4);
            gyrY = data(:,5);
            gyrZ = data(:,6);
        else
            accX = data(:,2)/g;
            accY = data(:,3)/g;
            accZ = data(:,4)/g+1;

            gyrX = data(:,5);
            gyrY = data(:,6);
            gyrZ = data(:,7);
        end
    end
    
    
    time = 0:samplePeriod:(length(data(:,1))-1)*samplePeriod;
    startTime = 0;
    stopTime = time(end);
    
    % -------------------------------------------------------------------------
    % Manually frame data
    
    indexSel = find(sign(time-startTime)+1, 1) : find(sign(time-stopTime)+1, 1);
    time = time(indexSel);
    gyrX = gyrX(indexSel, :);
    gyrY = gyrY(indexSel, :);
    gyrZ = gyrZ(indexSel, :);
    accX = accX(indexSel, :);
    accY = accY(indexSel, :);
    accZ = accZ(indexSel, :);
    
    % -------------------------------------------------------------------------
    % Detect stationary periods
    
    % Compute accelerometer magnitude
    acc_mag = sqrt((accX) .* (accX) + (accY) .* (accY) + (accZ) .* (accZ));
    gyr_mag = sqrt((gyrX) .* (gyrX) + (gyrY) .* (gyrY) + (gyrZ) .* (gyrZ));
       
    % HP filter accelerometer data
    filtCutOff = 0.001; %0.001
    [b, a] = butter(1, (2*filtCutOff)/(1/samplePeriod), 'high');
    acc_magFilt = filtfilt(b, a, acc_mag);
    gyr_magFilt = filtfilt(b, a, gyr_mag);
    
    % Compute absolute value
    acc_magFilt = abs(acc_magFilt);
    gyr_magFilt = abs(gyr_magFilt);
    
    % LP filter accelerometer data
    filtCutOff = 2; %2
    [b, a] = butter(1, (2*filtCutOff)/(1/samplePeriod), 'low');
    acc_magFilt = filtfilt(b, a, acc_magFilt);
    gyr_magFilt = filtfilt(b, a, gyr_magFilt);

    %Threshold detection
    % Thresholds will need to be adjusted on a per gesture basis.
    if (GestureName == "Nose")     
        tempPeak = findpeaks(acc_magFilt, 'MinPeakProminence', max(acc_magFilt) * 0.35);
        
        for stationaryStart = 0.05:0.05:0.25
            stationary = (acc_magFilt < max(0.025, stationaryStart * tempPeak(1))) & ...
                (gyr_magFilt < 500 * stationaryStart);
            if ( (mean(stationary(1:50)))<1  )

            else
                break;
            end
        end

        %l = min([find(stationary<1,1) find(abs(gyrXTemp)>10,1,'first') find(abs(gyrYTemp)>10,1,'first') find(abs(gyrZTemp)>10,1,'first')]);
        l = find(stationary<1, 1);
        for stationaryStop = 0.05:0.05:0.25
            stationary = (acc_magFilt < stationaryStop * max(0.025, tempPeak(length(tempPeak)))) & ...
                (gyr_magFilt < 500 * stationaryStop);
            if (   (mean(stationary((end-50):end))) < 1  )

            else
                break;
            end
        end

        stationary(1:l) = 1;
        %r = max([find(stationary<1,1, 'last') find(abs(gyrXTemp)>10,1,'last') find(abs(gyrYTemp)>10,1,'last') find(abs(gyrZTemp)>10,1,'last')]);
        r = find(stationary<1, 1, 'last');
        mt_imu_with_stationary = r-l;

        [acc_peaks, acc_peaks_x] = findpeaks(acc_magFilt(l:r), 'MinPeakProminence', max(acc_magFilt(l:r)) * 0.35);
        % Depending on the gesture, expected number of peaks and vallies
        % will need to be adjusted as well as stationary period within the
        % main gesture part. Currently it finds the local minimum and marks
        % everything within 1.5% of the minimum as stationary. This will
        % need to be tuned based on average results accuracy.
        acc_gest_stat = zeros(length(acc_magFilt(l:r)), 1);
        for i = 1:1:length(acc_peaks) - 1
            acc_gest_stat(acc_peaks_x(i):acc_peaks_x(i + 1)) = acc_gest_stat(acc_peaks_x(i):acc_peaks_x(i + 1)) | ...
                (acc_magFilt(l + acc_peaks_x(i):l + acc_peaks_x(i + 1)) < 0.015 * ...
                ((max(acc_magFilt(l + acc_peaks_x(i):l + acc_peaks_x(i + 1)))) - ...
                min(acc_magFilt(l + acc_peaks_x(i):l + acc_peaks_x(i + 1)))) + ...
                min(acc_magFilt(l + acc_peaks_x(i):l + acc_peaks_x(i + 1))));
        end

        [gyr_peaks, gyr_peaks_x] = findpeaks(gyr_magFilt(l:r), 'MinPeakProminence', max(gyr_magFilt(l:r)) * 0.35);

        gyr_gest_stat = zeros(length(gyr_magFilt(l:r)), 1);
        for i = 1:1:length(gyr_peaks) - 1
            gyr_gest_stat(gyr_peaks_x(i):gyr_peaks_x(i + 1)) = gyr_gest_stat(gyr_peaks_x(i):gyr_peaks_x(i + 1)) | ...
                (gyr_magFilt(l + gyr_peaks_x(i):l + gyr_peaks_x(i + 1)) < 0.015 * ...
                ((max(gyr_magFilt(l + gyr_peaks_x(i):l + gyr_peaks_x(i + 1)))) - ...
                min(gyr_magFilt(l + gyr_peaks_x(i):l + gyr_peaks_x(i + 1)))) + ...
                min(gyr_magFilt(l + gyr_peaks_x(i):l + gyr_peaks_x(i + 1))));
        end

        stationary(l:r) = acc_gest_stat | gyr_gest_stat;
    else
        for stationaryStart = 0.025:0.002:0.1
            stationary = acc_magFilt < stationaryStart;
            if ( (mean(stationary(1:20)))<1  )

            else
                break;
            end
        end

        l = min([find(stationary<1,1) find(abs(gyrXTemp)>10,1,'first') find(abs(gyrYTemp)>10,1,'first') find(abs(gyrZTemp)>10,1,'first')]);

        for stationaryStop = 0.025:0.002:0.1
            stationary = acc_magFilt < stationaryStop;
            if (   (mean(stationary((end-20):end))) < 1  )

            else
                break;
            end
        end

        stationary(1:l) = 1;
        r = max([find(stationary<1,1, 'last') find(abs(gyrXTemp)>10,1,'last') find(abs(gyrYTemp)>10,1,'last') find(abs(gyrZTemp)>10,1,'last')]);
        mt_imu_with_stationary = r-l;

        stationary(l:r) = acc_magFilt(l:r) < stationaryThreshold;
    end
  
    % -------------------------------------------------------------------------
    % Compute orientation
    
    quat = zeros(length(time), 4);
    AHRSalgorithm = AHRS('SamplePeriod', 1/100, 'Kp', 5, 'KpInit', 0.1);
    
    % Initial convergence
    initPeriod = 0.2;
    indexSel = 1 : find(sign(time-(time(1)+initPeriod))+1, 1);
    for i = 1:200
        AHRSalgorithm.UpdateIMU([0 0 0], [mean(accX(indexSel)) mean(accY(indexSel)) mean(accZ(indexSel))]);
    end
    
    % For all data
    for t = 1:length(time)
        if(stationary(t))                       % Following Kp values may need to change based on output graph
            AHRSalgorithm.Kp = kpStat;          % 0.0 originally
        else
            AHRSalgorithm.Kp = kpMove;          % 1.0 originally
        end
        AHRSalgorithm.UpdateIMU(deg2rad([gyrX(t) gyrY(t) gyrZ(t)]), [accX(t) accY(t) accZ(t)]);
        quat(t,:) = AHRSalgorithm.Quaternion;
    end
    
    % -------------------------------------------------------------------------
    % Compute translational accelerations
    
    % Rotate body accelerations to Earth frame
    acc = quaternRotate([accX accY accZ], quaternConj(quat));
    
    % Convert acceleration measurements to m/s/s
    acc = acc * 9.81;
    
    % -------------------------------------------------------------------------
    % Compute translational velocities
    
    acc(:,3) = acc(:,3) - 9.81;    
    
    % Integrate acceleration to yield velocity
    vel = zeros(size(acc));
    for t = 2:length(vel)
        vel(t,:) = vel(t-1,:) + acc(t,:) * samplePeriod;
        if(stationary(t) == 1)
            vel(t,:) = [0 0 0];     % force zero velocity when foot stationary
        end
    end
    
    % Compute integral drift during non-stationary periods
    velDrift = zeros(size(vel));
    stationaryStart = find([0; diff(stationary)] == -1);
    stationaryEnd = find([0; diff(stationary)] == 1);
    if length(stationaryStart)<length(stationaryEnd)
        stationaryStart = [1; stationaryStart(1:end)];
    end
        
    for i = 1:numel(stationaryEnd)
        driftRate = vel(stationaryEnd(i)-1, :) / (stationaryEnd(i) - stationaryStart(i));
        enum = 1:(stationaryEnd(i) - stationaryStart(i));
        drift = [enum'*driftRate(1) enum'*driftRate(2) enum'*driftRate(3)];
        velDrift(stationaryStart(i):stationaryEnd(i)-1, :) = drift;
    end
    
    % Remove integral drift
    vel = vel - velDrift;    

    %% Assigning Filtered IMU Data to new variable.
    
    IMU_vx = vel(:,1);
    IMU_vy = vel(:,2);
    IMU_vz = vel(:,3);
        
    %% Data import, Domenico's Filter, and length correction happen above.
        
    IMUV = (sqrt(IMU_vx.^2 + IMU_vy.^2 +IMU_vz.^2)); 
    
    if IMUV(10) > 0.1 || IMUV(end) > 0.1
        disp(strcat("Trial ", TrialNum, ": Possible Bad Velocity Signals Calculated for Subject: ")) %Prints the error message to the command window.   
    end
    
    peakdetThres = 0.1;
    peakdetThres4 = 0;
    peakdetThres3 = 0;
    
    for i = 1:70  
        %Detect Peaks in Time Series (wmc)
        %IMU
        [maxtab_IMUV, mintab_IMUV] = peakdet(IMUV, peakdetThres);           % Check for number of peaks
                                                                            
        
        if length(maxtab_IMUV)>=3 && i<70
            
            if (length(maxtab_IMUV)==4)
                peakdetThres4 = peakdetThres;
            end
            
            if (length(maxtab_IMUV)==3)
                peakdetThres3 = peakdetThres;
            end
            
            peakdetThres = peakdetThres*1.05;
        else
            if i > 1
                peakdetThres = peakdetThres/1.05;
            end
            break;
        end
    end
    
    if peakdetThres4 >0
        peakdetThres=peakdetThres4;
    elseif peakdetThres3 >0
        peakdetThres=peakdetThres3;
    end
    
    [maxtab_IMUV, mintab_IMUV] = peakdet(IMUV, peakdetThres);
    
    if (length(maxtab_IMUV) > 5)
       disp("Unexpected number of peaks, possible gesture data error?");   % Depending on gesture, determine if warning needed
    end
   
    
    MinDuration = 50;
    %try
    %Onset
    if any(IMUV(maxtab_IMUV(1,1):-1:1)<maxtab_IMUV(1,2)*0.01)
        for onset_IMUV = maxtab_IMUV(1,1):-1:1
            
            if onset_IMUV - MinDuration > 1
                minZeroVelocityFrom =  onset_IMUV - MinDuration;
            else
                minZeroVelocityFrom = 1;
            end   
            
            if (IMUV(onset_IMUV)<maxtab_IMUV(1,2)*0.01 ) && (mean(IMUV(minZeroVelocityFrom:onset_IMUV))<0.05)
                break
            end
        end
    else
        for onset_IMUV = maxtab_IMUV(1,1):-1:1
            
            if onset_IMUV - MinDuration > 1
                minZeroVelocityFrom =  onset_IMUV - MinDuration;
            else
                minZeroVelocityFrom = 1;
            end

            
            if (IMUV(onset_IMUV)< maxtab_IMUV(1,2)*0.05) && (mean(IMUV(minZeroVelocityFrom:onset_IMUV))<0.1)
                break
            end
        end
    end
    
    MinDuration = 75;
    
    sizeMaxtab = size(maxtab_IMUV);
        
    %Offset of IMU
    if any(IMUV(maxtab_IMUV(sizeMaxtab(1),1):1:end)<maxtab_IMUV(sizeMaxtab(1),2)*0.01)
        for offset_IMUV = (maxtab_IMUV(sizeMaxtab(1),1):1:length(IMUV)-1)
                  
            if offset_IMUV + MinDuration < length(IMUV)
                minZeroVelocityUntil =  offset_IMUV + MinDuration;
            else
                minZeroVelocityUntil = length(IMUV);
            end
            
            if (IMUV(offset_IMUV)< maxtab_IMUV(sizeMaxtab(1),2)*0.01) || ((mean(IMUV(offset_IMUV:minZeroVelocityUntil))<0.02) && (IMUV(offset_IMUV)< 0.005))
                break
            end
        end
    elseif any(IMUV(maxtab_IMUV(sizeMaxtab(1),1):1:size(IMUV)<maxtab_IMUV(sizeMaxtab(1),2)*0.05))
        for offset_IMUV = (maxtab_IMUV(sizeMaxtab(1),1):1:length(IMUV)-1)
            
            if offset_IMUV + MinDuration < length(IMUV)
                minZeroVelocityUntil =  offset_IMUV + MinDuration;
            else
                minZeroVelocityUntil = length(IMUV);
            end
            
            if (IMUV(offset_IMUV)< maxtab_IMUV(sizeMaxtab(1),2)*0.05) || ((mean(IMUV(offset_IMUV:minZeroVelocityUntil))<0.02) && (IMUV(offset_IMUV)< 0.005))
                break
            end
        end
    else
        [s, loc_offset_IMUV] = min(IMUV(maxtab_IMUV(sizeMaxtab(1),1):1:length(IMUV)-1));
        offset_IMUV = loc_offset_IMUV + maxtab_IMUV(sizeMaxtab(1),1) -1;
    end
      
    %% Trim Time Series
    %Plot Overall
    trimI = IMUV(onset_IMUV:offset_IMUV);
    writematrix(trimI, strcat(OutputPath, '\Velocity_', SubjectNum, '_', TrialNum, '.csv'));
    %catch
    %    disp(strcat("Trial ", TrialNum, ": Significant error, check raw data."));
    %end

    try  
        peakLoc = maxtab_IMUV(:,1);
        peakValues = maxtab_IMUV(:,2);
            
        temp = maxk(peakValues,3);
            
        %Name of variables are named in order of highest peak.
        peak1 = peakLoc(find(peakValues == temp(1), 1 ,'first'));
        peak2 = peakLoc(find(peakValues == temp(2), 1 ,'first'));
        peak3 = peakLoc(find(peakValues == temp(3), 1 ,'first'));
    catch                     % Need to rerun script with lower stationary threshold?
        errorText = strcat("Trial ", TrialNum, ": Error: 3 Peaks Not Detected.");
        disp(errorText) %Prints the error message to the command window.

        outcome = [TrialNum, errorText];
        %outcome = vertcat(outcome, errorEntry);
    end
    
    if mod(output_mode, 2)
        trimIx = IMU_vx(onset_IMUV:offset_IMUV);
        trimIy = IMU_vy(onset_IMUV:offset_IMUV);
        trimIz = IMU_vz(onset_IMUV:offset_IMUV);

        results = [func_SAL(trimIx, trimIy, trimIz), 10 * mean(trimI), 10 * (offset_IMUV - onset_IMUV)];
        writematrix(results, strcat(OutputPath, "\Stats_", SubjectNum, "_", TrialNum, ".csv"));
    end
    
    mean_vel = mean(trimI);
    max_vel = max(trimI);
    sal = func_SAL(trimIx, trimIy, trimIz);
    mtimu = 10 * (r - l);
    path_length = trapz(trimI);

if plot_mode == 1
    % -------------------------------------------------------------------------
        % Plot data raw sensor data and stationary periods
        f1 = figure(1);
        clf;
        f1.Visible = 'off';
        f1.Name = 'Raw IMU Sensor Data';
        
        ax(1) = subplot(2,1,1);
        hold on;
        plot(time, gyrX, 'r');
        plot(time, gyrY, 'g');
        plot(time, gyrZ, 'b');
        plot(time, gyr_magFilt, ':k');
        title('Gyroscope');
        xlabel('Time (s)');
        ylabel('Angular velocity (^\circ/s)');
        legend('X', 'Y', 'Z', 'Filtered');
        hold off;
        ax(2) = subplot(2,1,2);
        hold on;
        plot(time, accX, 'r');
        plot(time, accY, 'g');
        plot(time, accZ, 'b');
        plot(time, acc_magFilt, ':k');
        plot(time, stationary, 'k', 'LineWidth', 2);
        title('Accelerometer');
        xlabel('Time (s)');
        ylabel('Acceleration (g)');
        legend('X', 'Y', 'Z', 'Filtered', 'Stationary');
        hold off;
        linkaxes(ax,'x');

    f1.Visible='on';
    f1.Position = [50, 100, 560, 425];

    f70 = figure(70);
    clf;
    f70.Name = strcat("Trial ", TrialNum, ": Trimmed Resultant Data");
    f70.Visible = 'off';
    rescaledX = [0:10:(length(trimI) * 10) - 1];
    hold on; plot(rescaledX, trimI * 10, 'LineStyle', '--', 'Color', 'red', 'linewidth', 2)
    title('Resultant Velocity');
    legend('IMU');

    f70.Visible = 'on';
    f70.Position = [625, 100, 560, 425];
end

