TwilioSmsRaffle
===============

A Twilio SMS powered raffle winner picker WPF app.  To run a raffle using Twilio and this app you will need to do some configurating.

### Application Requirements

The raffle winner picker application is a WPF application built using Visual Studio 2013.  You will need a similar environment to open, build and run the project.

### Set Up A Raffle:

1. Go [sign up for a Twilio account](https://www.twilio.com/try-twilio).  In order to send and receive text messages to more than just your verified phone number you will need to upgrade to a full account.
2. Configure the Messaging Request URL for your Twilio phone number to bounce back a raffle registration ackowledgement. 

    ![Message Request URL](http://i.imgur.com/gGX938p.png)

    I normally use [Twimlbin](http://twimlbin.com/) to create some static TwiML:

        <Response>
            <Message>Thanks for registering for the event raffle.</Message>
        </Response>
    
3. Have participants text in their first & last names to your Twilio phone number to enter the raffle.

### Pick Random Raffle Winners

1. Log into your Twilio account, go to the Logs tab in the account dashboard and select the Messages logs.
2. Use the filter options to filter the logs for only messages to your raffle phone number during the raffle dates.
3. Use the _Export to CSV_ option to download the log to a CSV file:

    ![Export To CSV](http://i.imgur.com/wnoNwaI.png)

4. Open the TwilioSmsRaffle project in Visual Studio.
5. In the _MainWindow.xaml.cs_ file locate the _smsLogPath_ varaible and update it with the path to the SMS Log file CSV you downloaded in Step 3.

        string smsLogPath = @"[The_Twilio_Sms_Log_File_Path]";
    
6. Run the application and start to pick winners:

    ![Raffle App](http://i.imgur.com/LhatnDX.png)
    
    Winners can only be selected once.
