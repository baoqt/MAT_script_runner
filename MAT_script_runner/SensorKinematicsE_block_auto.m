

function [outcome] = SensorKinematicsE_block(InputPath, OutputPath, GestureName, SubjectNumInt, TrialNumInt, manTrimLeft, manTrimRight, plot_mode, stationaryThreshold, kpStat, kpMove)

%Activity: 1 Block, 2 Drink (Soda Can), 3 Water (Water Pouring), 4 for
%BicepCurls

%% Import Libraries
addpath('Quaternions');

%% Initialize Reference/Output Varibles

% Do Not Delete this section. This will make sure the csv output is as
% correct as possible should the script or test fail.
errorVelocity = 0;
errorScript = 0;
salimu = 0;
mtimu = 0;
ImaxVel = 0;
corrvaluex= 0; RMSE = 0; peakdetThres = 0;
jerkimu_dim =0;
jerkimu_dim_log =0;
ImaxVel = 0; ImeanVelocity =0;
ImaxAccel = 0;  ImeanAccel = 0;   stdAccel = 0;
TimeFromOnsetToLastPeak = 0;   TimeFromOnsetToFirstPeak =0;
TimeFromOnsetToHighestPeak = 0;   TimeFromOnsetToLowestPeak = 0;

if stationaryThreshold <= 0                     % assign defaults if specified in argumentss
    stationaryThreshold = 0.0025;                % 0.02
end

if kpStat == 0
    kpStat = 0;
end

if kpMove == 0
    kpMove = 0.5;     % 10
end


%% File Name Parameters:

SubjectNum = int2str(SubjectNumInt);

TrialNum = int2str(TrialNumInt);

%% IMU Data Entry (Paste Data or Read From File)
% Load IMU File
data = csvread(strcat(InputPath, '\', GestureName, '\', SubjectNum, '_', TrialNum, '.csv'), 0,1); % IMU file name will have one '_'
data = data(max([manTrimLeft 1]):(end-manTrimRight),:);

        %% Pre-Processing Filter
    
%         % LP filter all IMU data
        filtCutOff = 3;
        [b, a] = butter(1, (2*filtCutOff)/(1/0.01), 'low');
        data2 = filtfilt(b, a, data);

        %% Automatic Trimming of IMU

    g = 9.81;
    
    axTemp = (data2(:,1)/g);
    ayTemp = (data2(:,2)/g);
    azTemp = (data2(:,3)/g+1);
    
    gyrXTemp = data2(:,4);
    gyrYTemp = data2(:,5);
    gyrZTemp = data2(:,6);
    
    ac1_mag = sqrt(  (data2(:,1)/g).*(data2(:,1)/g)   +   (data2(:,2)/g).*(data2(:,2)/g)  +   (data2(:,3)/g+1).*(data2(:,3)/g+1)  );
    trimTempL1 = max([1 min([find( azTemp<0.7, 1,'first') find(abs(gyrXTemp)>10,1,'first') find(abs(gyrYTemp)>10,1,'first') find(abs(gyrZTemp)>10,1,'first') find( abs(ac1_mag-1) > 0.1 , 1,'first')])  ]);
    trimLeft = max([1 find( abs(ac1_mag(1:trimTempL1)-1) < 0.025 , 1,'last')-100]);
    
    if abs(azTemp(1)) > abs(ayTemp(1))
        trimTemp1 = min([length(data2)  max( [find( azTemp<0.7, 1,'last') find(abs(gyrXTemp)>5,1,'last') find(abs(gyrYTemp)>5,1,'last') find(abs(gyrZTemp)>5,1,'last')])]);
    else
        trimTemp1 = min([length(data2)  max( [find( ayTemp<0.7, 1,'last') find(abs(gyrXTemp)>5,1,'last') find(abs(gyrYTemp)>5,1,'last') find(abs(gyrZTemp)>5,1,'last')])]);
    end
    trimTemp2 = min([find( abs(ac1_mag(trimTemp1:end)-1)>0.1,1,'last')+trimTemp1 length(data2)] );
    trimTemp3 = min([find( abs(ac1_mag(trimTemp2:end)-1)<0.02,1,'last')+trimTemp2 length(data2)] );
    trimRight = min([find( abs(ac1_mag((trimTemp2+100):trimTemp3)-1)<0.0025,1,'last')+trimTemp2 length(data2)] );
    
    if plot_mode == 1
        f300 = figure(300);
        f300.Visible = 'off';
        clf;
        subplot(2,1,1)
        plot( ac1_mag , 'k')
        hold on;
        plot( data2(:,1)/g, 'r');
        plot( data2(:,2)/g, 'g');
        plot( data2(:,3)/g+1, 'b');
        plot(trimLeft, ac1_mag(trimLeft), 'g*', 'MarkerSize',20);
        plot(trimRight, ac1_mag(trimRight), 'r*', 'MarkerSize',20);
        plot(trimTempL1, ac1_mag(trimTempL1), 'ko' , 'MarkerSize',20);
        plot(trimTemp1, ac1_mag(trimTemp1), 'bo' , 'MarkerSize',20);
        plot(trimTemp2, ac1_mag(trimTemp2), 'go' , 'MarkerSize',20);
        plot(trimTemp3, ac1_mag(trimTemp3), 'ro' , 'MarkerSize',20);
        legend('Raw A Resultant Magnitude', 'Raw Ax', 'Raw Ay', 'Raw Az',  'Left Trim' , 'Right Trim', 'TempL1','TempR1', 'TempR2', 'TempR3')
        
        subplot(2,1,2)
        hold on;
        plot(abs(ac1_mag-1))
        legend('abs(A Resultant Magnitude)-1')
            
    end
    
    data = data(trimLeft:trimRight,:);
    data2 = data2(trimLeft:trimRight,:);
    axTemp = axTemp(trimLeft:trimRight,:);
    ayTemp = ayTemp(trimLeft:trimRight,:);
    axTemp = azTemp(trimLeft:trimRight,:);
    
    gyrXTemp = gyrXTemp(trimLeft:trimRight,:);
    gyrYTemp = gyrYTemp(trimLeft:trimRight,:);
    gyrZTemp = gyrZTemp(trimLeft:trimRight,:);

    %% IMU Data pre-processing on Import
    samplePeriod = 1/100;
    
    g = 9.81;
    accX = data(:,1)/g;
    accY = data(:,2)/g;
    accZ = data(:,3)/g+1;
    
    gyrX = data(:,4);
    gyrY = data(:,5);
    gyrZ = data(:,6);
    
    
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
    acc_mag = sqrt(  (data2(:,1)/g).*(data2(:,1)/g)   +   (data2(:,2)/g).*(data2(:,2)/g)  +   (data2(:,3)/g+1).*(data2(:,3)/g+1)  );
       
    % HP filter accelerometer data
    filtCutOff = 0.001; %0.001
    [b, a] = butter(1, (2*filtCutOff)/(1/samplePeriod), 'high');
    acc_magFilt = filtfilt(b, a, acc_mag);
    
    % Compute absolute value
    acc_magFilt = abs(acc_magFilt);
    
    % LP filter accelerometer data
    filtCutOff = 2; %2
    [b, a] = butter(1, (2*filtCutOff)/(1/samplePeriod), 'low');
    acc_magFilt = filtfilt(b, a, acc_magFilt); 

    %Threshold detection
    for stationaryStart = 0.025:0.002:0.1
        stationary = acc_magFilt < stationaryStart;
        if ( (mean(stationary(1:20)))<1  )
            
        else
            break;
        end
    end
    
    if plot_mode ==1
        stationaryStart
    end
    
    l = min([find(stationary<1,1) find(abs(gyrXTemp)>10,1,'first') find(abs(gyrYTemp)>10,1,'first') find(abs(gyrZTemp)>10,1,'first')]);
    
    for stationaryStop = 0.025:0.002:0.1
        stationary = acc_magFilt < stationaryStop;
        if (   (mean(stationary((end-20):end))) < 1  )
            
        else
            break;
        end
    end
    
    if plot_mode ==1
        stationaryStop
    end
    
    stationary(1:l) = 1;
    r = max([find(stationary<1,1, 'last') find(abs(gyrXTemp)>10,1,'last') find(abs(gyrYTemp)>10,1,'last') find(abs(gyrZTemp)>10,1,'last')]);
    mt_imu_with_stationary = r-l;
    
    stationary(l:r) = acc_magFilt(l:r) < stationaryThreshold;
    
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
        title('Gyroscope');
        xlabel('Time (s)');
        ylabel('Angular velocity (^\circ/s)');
        legend('X', 'Y', 'Z');
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
    
    if plot_mode == 1
        f3 = figure(3);
        clf;
        f3.Visible = 'off';
        f3.Name = 'IMU Velocity and Position';
        subplot (2,1,1); hold on;
        plot(time, acc(:,1), 'r');
        plot(time, acc(:,2), 'g');
        plot(time, acc(:,3), 'b');
        title('Acceleration');
        xlabel('Time (s)');
        ylabel('Acceleration (m/s/s)');
        legend('X', 'Y', 'Z');
        hold off;
        
        subplot (2,1,2)
        hold on;
        plot(time, vel(:,1), 'r');hold on;
        plot(time, vel(:,2), 'g');hold on;
        plot(time, vel(:,3), 'b');hold on;
        title('Velocity');
        xlabel('Time (s)');
        ylabel('Velocity (m/s)');
        legend('X', 'Y', 'Z');
        hold off;
        
    end
    
    % -------------------------------------------------------------------------
    % Compute translational position
    
    % Integrate velocity to yield position
    pos = zeros(size(vel));
    for t = 2:length(pos)
        pos(t,:) = pos(t-1,:) + vel(t,:) * samplePeriod;    % integrate velocity to yield position
    end
    
    % -------------------------------------------------------------------------
    % Plot 3D  trajectory
    
    % % Remove stationary periods from data to plot
    posPlot = pos;
    quatPlot = quat;
    
    % Extend final sample to delay end of animation
    extraTime = 20;
    onesVector = ones(extraTime*(1/samplePeriod), 1);
    posPlot = [posPlot; [posPlot(end, 1)*onesVector, posPlot(end, 2)*onesVector, posPlot(end, 3)*onesVector]];
    quatPlot = [quatPlot; [quatPlot(end, 1)*onesVector, quatPlot(end, 2)*onesVector, quatPlot(end, 3)*onesVector, quatPlot(end, 4)*onesVector]];
    
    %% Assigning Filtered IMU Data to new variable.
    
    IMU_vx = vel(:,1);
    IMU_vy = vel(:,2);
    IMU_vz = vel(:,3);
    
    IMU_ax = acc(:,1);
    IMU_ay = acc(:,2);
    IMU_az = acc(:,3);
        
    %% Data import, Domenico's Filter, and length correction happen above.
    
    IMUA =  sqrt(IMU_ax.^2 + IMU_ay.^2 + IMU_az.^2);
    
%     if plot_mode == 1
%         f69 = figure(69);
%         clf;
%         f69.Visible = 'off';
%         f69.Name = 'Sensor Data: Accelerations';
%         plot(IMUA)
%         title(strcat('Subject: ', int2str(SubjectNumInt), ' Trial: ', int2str(TrialNumInt),' Accelerations'));
%         legend('IMU');
%     end
    
    IMUV = (sqrt(IMU_vx.^2 + IMU_vy.^2 +IMU_vz.^2));
    
    
    if IMUV(10) > 0.1 || IMUV(end) > 0.1
        errorVelocity = 1;
        strcat('Error: Possible Bad Velocity Signals Calculated for Subject: ', int2str(SubjectNumInt), ' Trial: ', int2str(TrialNumInt)) %Prints the error message to the command window.
        
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
       fprintf('Unexpected number of peaks, possible gesture data error?\n');   % Depending on gesture, determine if warning needed
    end
    
%     if plot_mode == 1
%         
%         f68 = figure(68);
%         clf;
%         f68.Visible = 'off';
%         f68.Name = 'Sensor Data: Velocities';
%         hold on;
%         
%     end
    
    %IMU
    
    if plot_mode == 1
        plot (IMUV, 'b'); hold on
        plot(maxtab_IMUV(:,1), maxtab_IMUV(:,2), 'k*');hold on; title(strcat('Subject: ', int2str(SubjectNumInt), ' Trial: ', int2str(TrialNumInt),' Resultant Velocity'));
    end
    
    MinDuration = 50;
    
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
    
    if plot_mode == 1
        plot(onset_IMUV, IMUV(onset_IMUV), 'r*');
        plot(offset_IMUV, IMUV(offset_IMUV), 'r*');
        legend('IMU', 'IMU Peak' , 'IMU Onset', 'IMU Offset');
    end
      
    %% Trim Time Series
    %Plot Overall
    trimI = IMUV(onset_IMUV:offset_IMUV);
%    csvwrite(strcat('DataGondar/Output/velocity.csv'),trimI);
    
    if plot_mode == 1
        f70 = figure(70);
        clf;
        f70.Name = 'Trimmed Resultant Data';
        f70.Visible = 'off';
        hold on; plot(trimI * 10, 'linewidth', 2)
        title('Resultant Velocity');
        legend('IMU');
    end
    
    %Trim all axes for IMU
    trimIx = IMU_vx(onset_IMUV:offset_IMUV);
    trimIy = IMU_vy(onset_IMUV:offset_IMUV);
    trimIz = IMU_vz(onset_IMUV:offset_IMUV);
     
    %----------------------------Kinematic Variables-------------------
    %Movement Time
    mtimu = (offset_IMUV-onset_IMUV); %value depends on sampling rate
    
    %Movement Smoothness
    salimu = func_SAL(trimIx, trimIy, trimIz);
    [jerkimu_dim,jerkimu_dim_log] = func_jerk_dim(trimIx, trimIy, trimIz);
    
    %Max Velocity
    ImaxVel = max(IMUV);
    
    %Max Acceleration
    ImaxAccel = max(IMUA);
    
    %Mean Acceleration
    ImeanAccel = mean(IMUA(onset_IMUV:offset_IMUV));
    
    %Mean Velocity
    ImeanVelocity = mean(IMUV(onset_IMUV:offset_IMUV));
    
    %Variability of Mean Accel
    stdAccel = std2(IMUA(onset_IMUV:offset_IMUV));
      
    try  
        peakLoc = maxtab_IMUV(:,1);
        peakValues = maxtab_IMUV(:,2);
            
        temp = maxk(peakValues,3);
            
        %Name of variables are named in order of highest peak.
        peak1 = peakLoc(find(peakValues == temp(1), 1 ,'first'));
        peak2 = peakLoc(find(peakValues == temp(2), 1 ,'first'));
        peak3 = peakLoc(find(peakValues == temp(3), 1 ,'first'));
                     
        %Time From Onset to Peaks (for Velocity)
        TimeFromOnsetToLastPeak = max([peak1 peak2 peak3])-onset_IMUV;
        TimeFromOnsetToFirstPeak = min([peak1 peak2 peak3])-onset_IMUV;

        TimeFromOnsetToHighestPeak =  peakLoc(find(peakValues == max(temp), 1 ,'first'))-onset_IMUV;
        TimeFromOnsetToLowestPeak =  peakLoc(find(peakValues == min(temp), 1 ,'first'))-onset_IMUV;
    catch ME                     % Need to rerun script with lower stationary threshold?
        strcat('Error: 3 Peaks Not Detected.  Subject: ', int2str(SubjectNumInt), ' Trial: ', int2str(TrialNumInt)) %Prints the error message to the command window.
    end
        
    outcome = [SubjectNumInt, TrialNumInt, salimu, mtimu,  jerkimu_dim,  jerkimu_dim_log, ImaxVel, ImeanVelocity, ImaxAccel,  ImeanAccel,   stdAccel, TimeFromOnsetToLastPeak,   TimeFromOnsetToFirstPeak,    TimeFromOnsetToHighestPeak,   TimeFromOnsetToLowestPeak, corrvaluex, RMSE, errorVelocity, errorScript];
    csvwrite(strcat(OutputPath, '\', GestureName, '\', SubjectNum, '_', TrialNum, '.csv'),outcome);

if plot_mode == 1
    
    f1.Visible='on';
%    f3.Visible='on';
%    f68.Visible = 'on';
%    f300.Visible = 'on';
    
%    f69.Visible='on';
    f70.Visible = 'on';
    
%   f68 = figure(68);
%   f68.Position = [360 278 700 942];
    
%    saveas(f68,strcat('DataGondar/OutputFigures/Block/Subject ', int2str(SubjectNumInt), ' Trial ', int2str(TrialNumInt),' Resultant Velocity.png'))
end

