<?php

namespace App\Console\Commands;

use Illuminate\Console\Command;
use App\Models\User;
use App\Models\Setting;
use Auth;
use DB;

class InitializeAndGenerateTestToken extends Command
{
    protected $signature = 'snipeit:initialize-test
                                {--username=test} {--password=password}
                                {--first-name=Test} {--last-name=Admin}
                                {--email-domain=example.localhost : The admin email address will be the username plus this}
                                {--currency=USD} {--locale=en} {--full-multiple-companies-support} {--auto-increment-prefix=test}';
    protected $description = 'TODO command description';
    public function __construct()
    {
        parent::__construct();
    }
    public function handle()
    {
        # TODO: guard. This should only be run on empty instances.
        $this->warn('This command is inherently insecure, and only to be used for testing purposes. Use at your own risk.');
        $this->info('Migrating database.');
        $this->call('migrate', [ '--force' => true ]);
        if ((!file_exists(storage_path().'/oauth-private.key')) || (!file_exists(storage_path().'/oauth-public.key'))) {
            $this->call('migrate', ['--force' => true]);
            $this->call('passport:install');
        }

        $this->info('Initializing test user');
        $Options = $this->options();
        $UserName = $Options['username'] ?: 'test';
        $EmailDomain = $Options['email-domain'] ?: 'example.localhost';
        $AlertEmail = "$UserName@$EmailDomain";
        $User = new User;
        $User->first_name = $Options['first-name'] ?: 'Test';
        $User->last_name = $Options['last-name'] ?: 'Admin';
        $User->email = $AlertEmail;
        $User->activated = 1;
        $User->permissions = json_encode([ 'superuser' => 1 ]);
        $User->username = $UserName;
        $User->password = bcrypt($Options['password'] ?: 'password');
        if(!$User->isValid()){
            throw new \Exception('User is not valid! ' . var_export($User->getErrors(), true));
        }

        $this->info('Initializing test settings');
        $Settings = new Setting;
        $Settings->alert_email = $AlertEmail;
        $Settings->alerts_enabled = 0;
        $Settings->auto_increment_assets = 0;
        $Settings->auto_increment_prefix = $Options['auto-increment-prefix'] ?: 'test';
        $Settings->brand = 1; # Default from SettingsController.php
        $Settings->default_currency = $Options['currency'] ?: 'USD';
        $Settings->email_domain = $EmailDomain;
        $Settings->email_format = 'filastname';
        $Settings->full_multiple_companies_support = $Options['full-multiple-companies-support'] ? 1 : 0;
        $Settings->locale = $Options['locale'] ?: 'en';
        $Settings->next_auto_tag_base = 1; # Default from SettingsController.php
        $Settings->pwd_secure_min = 8; # Default from DB
        $Settings->site_name = 'SnipeIT SnipeSharp Test Container';
        $Settings->user_id = 1;
        if(!$Settings->isValid()){
            throw new \Exception('Settings are not valid! ' . var_export($Settings->getErrors(), true));
        }

        $this->info('Saving user.');
        if(!$User->save()){
            throw new \Exception('Failed to save user.');
        }
        $this->info('Logging in as user.');
        Auth::login($User, true);
        $this->info('Saving settings.');
        if(!$Settings->save()){
            throw new \Exception('Failed to save settings.');
        }

        $this->info('Generating API token');
        $User = User::where('username', '=', $UserName)->firstOrFail();
        $Token = $User->createToken('Snipe-IT Test API Token')->accessToken;
        DB::statement('CREATE TABLE `snipe_it_test_token` (`id` int(10) unsigned NOT NULL AUTO_INCREMENT, token text, PRIMARY KEY (`id`))');
        DB::insert('INSERT INTO `snipe_it_test_token` VALUES (?, ?)', [1, $Token]);
        $this->line(json_encode([ 'accessToken' => $Token ]));
    }
}
