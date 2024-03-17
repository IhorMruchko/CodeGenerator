# CodeGenerator
## Project team
<details>
<summary>UX developer</summary>

### Responsibilities
* Create responsible design;
* Provide proper data transition and information update;
* Create responsible design for different platforms.
</details>

<details>
<summary>Platform developer</summary>

### Responsibilities
* Handle library releases
* Provide documentation for the user-library
* Cross-platform developing
</details>

<details>
<summary>Project manager</summary>

### Responsibilities
* Inform stakeholders on the updates and developing progress
* Supply proper user-stories and stakeholders' requirements
* Handle project releases
</details>

<details>
<summary>Tester</summary>

### Responsibilities
* Confirm project usability
* Test updating and supply testing chain
</details>

## Project goals
<details>
<summary>To do</summary>

- [ ] Create user-friendly interface to help user get along with libriary
- [ ] Craete Nuget libriary to share code within other programmers
- [ ] Create web-page to share updates, news and tutorials
- [ ] Integrate project for different platforms.
- [ ] Support different programming languages.
- [ ] Provide cloud data storage
- [ ] Create cross-device code imports and exports.
</details>
<details>
<summary>Done</summary>

</details>

## Schedule
<details>
<summary>
Project Schedule
</summary>

![Code generator schedule](https://github.com/IhorMruchko/CodeGenerator/assets/55592478/d891f6ea-9c54-4cfd-9edb-da6f0027f376?raw=true)

</details>

## User stories
<details>
<summary> 
User stories
</summary>

<table>
    <thead>
        <tr>
            <th>№</th>
            <th>Title</th>
            <th>Priority</th>
            <th>Estimate</th>
        </tr>
    </thead>
    <tbody>
        <tr>
            <td>1</td>
            <td>Sign up</td>
            <td>High</td>
            <td>2 days</td>
        </tr>
      <tr>
        <td colspan=4 width=500>
          <b>User Story:</b> </br>
          As a user, </br>
          I want to get access to the full functionality of the application </br>
          so that all actions can be saved and restored. </br>
        </td>
      </tr>
      <tr>
        <td colspan=4>
          <b>Acceptance Criteria:</b> </br>
          Given unregistered user without an account. </br>
          When user registers. </br>
          Then give an access to the application features. </br>
        </td>
      </tr>
      <tr>
        <td>2</td>
        <td>Log in</td>
        <td>High</td>
        <td>2 days</td>
      </tr>
      <tr>
        <td colspan=4 width=500>
          <b>User Story:</b> </br>
          As a registered user, </br>
          I want to access my generated code and saved templates for it </br>
          so that can simplify code storaging and sharing. </br>
        </td>
      </tr>
      <tr>
        <td colspan=4>
          <b>Acceptance Criteria:</b> </br>
          Given registered user. </br>
          When he enteres right username and password. </br>
          Then give him an access to his code and data. </br>
        </td>
      </tr>
    <tr>
      <td>3</td>
      <td>Autorization and security</td>
      <td>High</td>
      <td>5 hours</td>
    </tr>
    <tr>
      <td colspan=4 width=500>
        <b>User Story:</b> </br>
        As a registered user, </br>
        I want to be sure that my code will be secured </br>
        so that save my code from the unacceptable access. </br>
      </td>
    </tr>
    <tr>
      <td colspan=4>
        <b>Acceptance Criteria:</b> </br>
        Given user. </br>
        When he tries to enter username or password and one of them is wrong. </br>
        Then send him e-mail about these attemps. </br>
      </td>
    </tr>
  <tr>
    <td>4</td>
    <td>Reset password</td>
    <td>High</td>
    <td>3 hours</td>
  </tr>
  <tr>
    <td colspan=4 width=500>
      <b>User Story:</b> </br>
      As a registered user, </br>
      I want to reset my password in case I forgotten it </br>
      so that makes easely enter the application. </br>
    </td>
  </tr>
  <tr>
    <td colspan=4>
      <b>Acceptance Criteria:</b> </br>
      Given registered user with forgotten password. </br>
      When user press forgot password button. </br>
      Then email with password reset token send. </br>
    </td>
  </tr>
  <tr>
    <td>5</td>
    <td>Double verification</td>
    <td>Default</td>
    <td>7 hours</td>
  </tr>
  <tr>
    <td colspan=4 width=500>
      <b>User Story:</b> </br>
      As a registered user, </br>
      I want to set double verification </br>
      so that makes my account more secured. </br>
    </td>
  </tr>
  <tr>
    <td colspan=4>
      <b>Acceptance Criteria:</b> </br>
      Given registered user with provided phone number and turned on double notification setting </br>
      When user enters the application </br>
      Then special code will be send to the his phone number </br>
    </td>
  </tr>
 <tr>
    <td>6</td>
    <td>Multilingual support</td>
    <td>Default</td>
    <td>7 hours</td>
  </tr>
  <tr>
    <td colspan=4 width=500>
      <b>User Story:</b> </br>
      As a registered user, </br>
      I want to set my native language of the UI </br>
      so that gives an clear understanding of what is displayed. </br>
    </td>
  </tr>
  <tr>
    <td colspan=4>
      <b>Acceptance Criteria:</b> </br>
      Given registered user </br>
      When user changes language settings </br>
      Then all specified translatable blocks will be translated. </br>
    </td>
  </tr>
<tr>
    <td>7</td>
    <td>Manual language edit</td>
    <td>Low</td>
    <td>3 days</td>
  </tr>
  <tr>
    <td colspan=4 width=500>
      <b>User Story:</b> </br>
      As a registerd user, </br>
      I want to be able to add my own translation if I am a native speaker </br>
      so that helps the application to grow and increase usability of the project. </br>
    </td>
  </tr>
  <tr>
    <td colspan=4>
      <b>Acceptance Criteria:</b> </br>
      Given registered user </br>
      When user provides translations of the specific UI item </br>
      Then this data will be saved as a custom user translation dictionary and it will be possible to suggest this translation as an translation on the application level. </br>
    </td>
  </tr>
<tr>
    <td>8</td>
    <td>Suggest translation</td>
    <td>Low</td>
    <td>7 hours</td>
  </tr>
  <tr>
    <td colspan=4 width=500>
      <b>User Story:</b> </br>
      As a registered user with a custom translation, </br>
      I want to suggest this translation for developers to add this one to the application in the future release </br>
      so that helps extend translational base of the application. </br>
    </td>
  </tr>
  <tr>
    <td colspan=4>
      <b>Acceptance Criteria:</b> </br>
      Given registered user with custom translation </br>
      When suggest button on the localization setting page pressed </br>
      Then this request sends to the developer, converted as itegratable code. </br>
    </td>
  </tr>
<tr>
    <td>9</td>
    <td>Differrent themes</td>
    <td>Low</td>
    <td>8 hours</td>
  </tr>
  <tr>
    <td colspan=4 width=500>
      <b>User Story:</b> </br>
      As a registered user, </br>
      I want to change UI appearence </br>
      so that can make UI more friendly and flexible. </br>
    </td>
  </tr>
  <tr>
    <td colspan=4>
      <b>Acceptance Criteria:</b> </br>
      Given registered user </br>
      When user changes the theme setting on the setting page </br>
      Then UI will be updated on the specified theme </br>
    </td>
  </tr>
<tr>
    <td>10</td>
    <td>Get access to the theme base</td>
    <td>Low</td>
    <td>3 hours</td>
  </tr>
  <tr>
    <td colspan=4 width=500>
      <b>User Story:</b> </br>
      As a registered user, </br>
      I want to be able to install different themes </br>
      so that makes UI more flexible and adaptable. </br>
    </td>
  </tr>
  <tr>
    <td colspan=4>
      <b>Acceptance Criteria:</b> </br>
      Given registered user </br>
      When user instals theme to the application </br>
      Then it can be visible on the theme setting </br>
    </td>
  </tr>
<tr>
    <td>11</td>
    <td>Add ability to create custom theme</td>
    <td>Low</td>
    <td>5 hours</td>
  </tr>
  <tr>
    <td colspan=4 width=500>
      <b>User Story:</b> </br>
      As a user-programmer or user, </br>
      I want to be able to create custom theme and apload it to the themes' base </br>
      so that helps extend application functionality and apearence. </br>
    </td>
  </tr>
  <tr>
    <td colspan=4>
      <b>Acceptance Criteria:</b> </br>
      Given registered user </br>
      When he set up custom theme </br>
      Then suggest him to upload this theme to the application base. In case user agreed - updload this to the public access. </br>
    </td>
  </tr>
<tr>
    <td>12</td>
    <td>Create code-generation project</td>
    <td>High</td>
    <td>5 days</td>
  </tr>
  <tr>
    <td colspan=4 width=500>
      <b>User Story:</b> </br>
      As a registered user, </br>
      I want to create new project </br>
      so that I can generate my new code. </br>
    </td>
  </tr>
  <tr>
    <td colspan=4>
      <b>Acceptance Criteria:</b> </br>
      Given registered user </br>
      When user press "Craete" button on the code generation screan </br>
      Then new project will be created, saved and be visible for the user on the projects screan. </br>
    </td>
  </tr>
<tr>
    <td>13</td>
    <td>View all created projects</td>
    <td>High</td>
    <td>4 days</td>
  </tr>
  <tr>
    <td colspan=4 width=500>
      <b>User Story:</b> </br>
      As a registered user, </br>
      I want to be able to see all my projects created via the application </br>
      so that I can access any project to view all generated code. </br>
    </td>
  </tr>
  <tr>
    <td colspan=4>
      <b>Acceptance Criteria:</b> </br>
      Given registered user </br>
      When user opens projects screan </br>
      Then all his projects will be loaded and displayed on the latest version of them </br>
    </td>
  </tr>
<tr>
    <td>14</td>
    <td>Change projects view type</td>
    <td>Default</td>
    <td>2 days</td>
  </tr>
  <tr>
    <td colspan=4 width=500>
      <b>User Story:</b> </br>
      As a registered user, </br>
      I want to be able to view all my projects in different vays (as treeview, as galery view) </br>
      so that makes code finding easy. </br>
    </td>
  </tr>
  <tr>
    <td colspan=4>
      <b>Acceptance Criteria:</b> </br>
      Given registered user on the projects screan </br>
      When user changes apearene of the view to another one </br>
      Then all projects will be displayed in selected view.  </br>
    </td>
  </tr>
<tr>
    <td>15</td>
    <td>Make project view editable</td>
    <td>Low</td>
    <td>2 hours</td>
  </tr>
  <tr>
    <td colspan=4 width=500>
      <b>User Story:</b> </br>
      As a user-programmer, </br>
      I want to create my own apearence using application </br>
      so that extends application functionality dinamicly. </br>
    </td>
  </tr>
  <tr>
    <td colspan=4>
      <b>Acceptance Criteria:</b> </br>
      Given registered programming user </br>
      When he generates code to display projects and send it to the application developers. </br>
      Then suggested view will be added to the application. </br>
    </td>
  </tr>
<tr>
    <td>16</td>
    <td>View specific code project</td>
    <td>High</td>
    <td>1 week</td>
  </tr>
  <tr>
    <td colspan=4 width=500>
      <b>User Story:</b> </br>
      As a registered user, </br>
      I want to open specific project to view generated code </br>
      so that I can user this code repeatedly. </br>
    </td>
  </tr>
  <tr>
    <td colspan=4>
      <b>Acceptance Criteria:</b> </br>
      Given registered user on the projects screan </br>
      When user presses on the specific project view  </br>
      Then he will be redirected to the project code view page </br>
    </td>
  </tr>
<tr>
    <td>17</td>
    <td>Edit project code</td>
    <td>High</td>
    <td>2 weeks</td>
  </tr>
  <tr>
    <td colspan=4 width=500>
      <b>User Story:</b> </br>
      As a registered user, </br>
      I want to be able to edit my code within the application </br>
      so that I can modify code without using any other code-editors. </br>
    </td>
  </tr>
  <tr>
    <td colspan=4>
      <b>Acceptance Criteria:</b> </br>
      Given registered user on the specific project view screan</br>
      When he presses edit button </br>
      Then specific project view turns into mutable code-base. </br>
    </td>
  </tr>
<tr>
    <td>18</td>
    <td>Upload existing files to the application</td>
    <td>High</td>
    <td>2 weeks</td>
  </tr>
  <tr>
    <td colspan=4 width=500>
      <b>User Story:</b> </br>
      As a registered user, </br>
      I want to be able to upload existing project to the application</br>
      so that will increase usablity of the application with another code-editors. </br>
    </td>
  </tr>
  <tr>
    <td colspan=4>
      <b>Acceptance Criteria:</b> </br>
      Given registered user </br>
      When user presses "Add" button on the projects screan </br>
      Then give user an opportunity to select localy stored code and upload this file to the appication. </br>
    </td>
  </tr>
<tr>
    <td>19</td>
    <td>Upload files to the specific project</td>
    <td>High</td>
    <td>3 days</td>
  </tr>
  <tr>
    <td colspan=4 width=500>
      <b>User Story:</b> </br>
      As a registered user, </br>
      I want to upload some files, not all project to the application </br>
      so that will maka application's projects more editable and flexible. </br>
    </td>
  </tr>
  <tr>
    <td colspan=4>
      <b>Acceptance Criteria:</b> </br>
      Given registered user on the specific project view screan </br>
      When user presses "Add" button </br>
      Then open file explorer and upload selected file(s) to the project code base </br>
    </td>
  </tr>
<tr>
    <td>20</td>
    <td>Delete some files from the project</td>
    <td>High</td>
    <td>6 hours</td>
  </tr>
  <tr>
    <td colspan=4 width=500>
      <b>User Story:</b> </br>
      As a registered user, </br>
      I want to delete the project I have created </br>
      so that remove all unnessesary code from my viewer. </br>
    </td>
  </tr>
  <tr>
    <td colspan=4>
      <b>Acceptance Criteria:</b> </br>
      Given registered user on the specific project view screan </br>
      When user hover over the file </br>
      Then display the delete button and after pressign delete the file(s) from the project </br>
    </td>
  </tr>
<tr>
    <td>21</td>
    <td>Ensure deletion</td>
    <td>High</td>
    <td>2 hours</td>
  </tr>
  <tr>
    <td colspan=4 width=500>
      <b>User Story:</b> </br>
      As a user </br>
      I want to be warned before the deletion of the file(s) </br>
      so that can save me from the deletion of the wrong files. </br>
    </td>
  </tr>
  <tr>
    <td colspan=4>
      <b>Acceptance Criteria:</b> </br>
      Given registeed user </br>
      When he presses delete button on the file view</br>
      Then display warning dialog including all files that will be deleted after confirming </br>
    </td>
  </tr>
<tr>
    <td>22</td>
    <td>Syncronize deletion of the file</td>
    <td>Default</td>
    <td>4 hours</td>
  </tr>
  <tr>
    <td colspan=4 width=500>
      <b>User Story:</b> </br>
      As a registered user, </br>
      I want to be able to delete file not only from the application and even from my computer </br>
      so that saves time of edition project in several places. </br>
    </td>
  </tr>
  <tr>
    <td colspan=4>
      <b>Acceptance Criteria:</b> </br>
      Given registed user with confirmed deletion  </br>
      When warning dialog appears, suggest user to delete files on his computer </br>
      Then delete files not only from the application but on the user's computer </br>
    </td>
  </tr>
<tr>
    <td>23</td>
    <td>All project deletion</td>
    <td>High</td>
    <td>2 days</td>
  </tr>
  <tr>
    <td colspan=4 width=500>
      <b>User Story:</b> </br>
      As a registered user, </br>
      I want to delete all project from the application </br>
      so that can remove unused code bases from the application. </br>
    </td>
  </tr>
  <tr>
    <td colspan=4>
      <b>Acceptance Criteria:</b> </br>
      Given registered user </br>
      When user presses delete button on the project after hovering above it </br>
      Then remove project reference from the application </br>
    </td>
  </tr>
<tr>
    <td>24</td>
    <td>Warning on project deletion</td>
    <td>High</td>
    <td>3 hours</td>
  </tr>
  <tr>
    <td colspan=4 width=500>
      <b>User Story:</b> </br>
      As a registered user, </br>
      I want to be warned that I am about to delete the project </br>
      so that saves me from the deletion of the wrong project. </br>
    </td>
  </tr>
  <tr>
    <td colspan=4>
      <b>Acceptance Criteria:</b> </br>
      Given registered user </br>
      When user presses delete project button </br>
      Then warning dialog will apear. </br>
    </td>
  </tr>
<tr>
    <td>25</td>
    <td>Delete all project on the computer</td>
    <td>Low</td>
    <td>2 hours</td>
  </tr>
  <tr>
    <td colspan=4 width=500>
      <b>User Story:</b> </br>
      As a registered user, </br>
      I want to delete project from the computer via the application </br>
      so that syncrhonize updates for different other applications. </br>
    </td>
  </tr>
  <tr>
    <td colspan=4>
      <b>Acceptance Criteria:</b> </br>
      Given registered user </br>
      When warning dialog apeares </br>
      Then suggest user to delete this project from his computer. </br>
    </td>
  </tr>
<tr>
    <td>26</td>
    <td>Adaptive programing language</td>
    <td>Default</td>
    <td>2 weeks</td>
  </tr>
  <tr>
    <td colspan=4 width=500>
      <b>User Story:</b> </br>
      As a user or programer-user, </br>
      I want to generate code for different programing languages </br>
      so that estends usability and grouping of the projects. </br>
    </td>
  </tr>
  <tr>
    <td colspan=4>
      <b>Acceptance Criteria:</b> </br>
      Given registered user or programmer-user </br>
      When he creates or addes new files to the project </br>
      Then suggest to select programming language </br>
    </td>
  </tr>
<tr>
    <td>27</td>
    <td>Responsible code structures</td>
    <td>High</td>
    <td>2 weeks</td>
  </tr>
  <tr>
    <td colspan=4 width=500>
      <b>User Story:</b> </br>
      As a registered user, </br>
      I want to see all possible code structures that can be generated within current working scope </br>
      so that simplifies code-generation setting. </br>
    </td>
  </tr>
  <tr>
    <td colspan=4>
      <b>Acceptance Criteria:</b> </br>
      Given registered user </br>
      When user works on the project </br>
      Then suggest next possible option on each generation step </br>
    </td>
  </tr>
<tr>
    <td>28</td>
    <td>Preview generation code</td>
    <td>High</td>
    <td>1 week</td>
  </tr>
  <tr>
    <td colspan=4 width=500>
      <b>User Story:</b> </br>
      As a registered user, </br>
      I want to preview generated code based on my settings </br>
      so that gives an opportunity to edit generation settings without actual generation. </br>
    </td>
  </tr>
  <tr>
    <td colspan=4>
      <b>Acceptance Criteria:</b> </br>
      Given registered user with draft code generation scenario </br>
      When user presses "preview" button </br>
      Then display how this code will be generated without actual generation. </br>
    </td>
  </tr>
<tr>
    <td>29</td>
    <td>Generate code</td>
    <td>High</td>
    <td>1 week</td>
  </tr>
  <tr>
    <td colspan=4 width=500>
      <b>User Story:</b> </br>
      As a registered user, </br>
      I want to generate my code after all is set up </br>
      so that can modify my code base. </br>
    </td>
  </tr>
  <tr>
    <td colspan=4>
      <b>Acceptance Criteria:</b> </br>
      Given registered user with all settings set </br>
      When user presses "generate" button </br>
      Then execute code generation on the user generation settings </br>
    </td>
  </tr>
<tr>
    <td>30</td>
    <td>Generate all user settings</td>
    <td>High</td>
    <td>2 weeks</td>
  </tr>
  <tr>
    <td colspan=4 width=500>
      <b>User Story:</b> </br>
      As a registered user, </br>
      I want to generate multiple files at once </br>
      so that make generation process easier. </br>
    </td>
  </tr>
  <tr>
    <td colspan=4>
      <b>Acceptance Criteria:</b> </br>
      Given registered user on the generation settigns page </br>
      When he presses "generate all" </br>
      Then generate all settings into files </br>
    </td>
  </tr>
<tr>
    <td>31</td>
    <td>Display generation process</td>
    <td>Default</td>
    <td>5 hours</td>
  </tr>
  <tr>
    <td colspan=4 width=500>
      <b>User Story:</b> </br>
      As a registered user, </br>
      I want to see the generation progress </br>
      so that gives me an understanding on what stage generation is. </br>
    </td>
  </tr>
  <tr>
    <td colspan=4>
      <b>Acceptance Criteria:</b> </br>
      Given registered user</br>
      When user is waiting untill code generates </br>
      Then display generation progress </br>
    </td>
  </tr>
<tr>
    <td>32</td>
    <td>Display errors</td>
    <td>High</td>
    <td>3 days</td>
  </tr>
  <tr>
    <td colspan=4 width=500>
      <b>User Story:</b> </br>
      As a registered user, </br>
      I want to know the reason why code was not generated </br>
      so that gives my understanding what should I change in the settings. </br>
    </td>
  </tr>
  <tr>
    <td colspan=4>
      <b>Acceptance Criteria:</b> </br>
      Given registered user with generation in progress </br>
      When generation goes failed </br>
      Then display the error and give a help to solve this problem </br>
    </td>
  </tr>
<tr>
    <td>33</td>
    <td>Store error localy</td>
    <td>High</td>
    <td>2 days</td>
  </tr>
  <tr>
    <td colspan=4 width=500>
      <b>User Story:</b> </br>
      As a registered user, </br>
      I want to see the errors on generation to know how to fix them in the future </br>
      so that simplify code creation. </br>
    </td>
  </tr>
  <tr>
    <td colspan=4>
      <b>Acceptance Criteria:</b> </br>
      Given registered user with failed code generation </br>
      When user closes the failing message viewer </br>
      Then store this error on the "Failed" tab to be able to view this message again </br>
    </td>
  </tr>
<tr>
    <td>34</td>
    <td>Delete error messages</td>
    <td>Default</td>
    <td>2 hours</td>
  </tr>
  <tr>
    <td colspan=4 width=500>
      <b>User Story:</b> </br>
      As a registered user, </br>
      I want to delete unused error messages </br>
      so that make all errors up-to-date and in use. </br>
    </td>
  </tr>
  <tr>
    <td colspan=4>
      <b>Acceptance Criteria:</b> </br>
      Given registered user with saved generation error </br>
      When user presses delete button on the specific error displayer </br>
      Then delete this error message from the list </br>
    </td>
  </tr>
<tr>
    <td>35</td>
    <td>Relative erorr messages</td>
    <td>Default > High</td>
    <td>4 days</td>
  </tr>
  <tr>
    <td colspan=4 width=500>
      <b>User Story:</b> </br>
      As a registered user, </br>
      I want to be able to track the palace where error occured </br>
      so that simplify fixing process. </br>
    </td>
  </tr>
  <tr>
    <td colspan=4>
      <b>Acceptance Criteria:</b> </br>
      Given registered user with generation failed message in list </br>
      When he presses "go to" button </br>
      Then redirect user to the file or project where this error occured </br>
    </td>
  </tr>
<tr>
    <td>36</td>
    <td>Integrate git</td>
    <td>High</td>
    <td>1 week 4 days</td>
  </tr>
  <tr>
    <td colspan=4 width=500>
      <b>User Story:</b> </br>
      As a registered user, </br>
      I want to be able to have different versions of the project </br>
      so that simplifies development process. </br>
    </td>
  </tr>
  <tr>
    <td colspan=4>
      <b>Acceptance Criteria:</b> </br>
      Given registered user with project in development </br>
      When user want to change version of the project </br>
      Then use git to control code changes with all git functionality </br>
    </td>
  </tr>
<tr>
    <td>37</td>
    <td>Cross-platform access</td>
    <td>Default</td>
    <td>4 weeks</td>
  </tr>
  <tr>
    <td colspan=4 width=500>
      <b>User Story:</b> </br>
      As a registered user, </br>
      I want to have an access to my projects from different platforms (web, desktop, mobile) </br>
      so that make user experience better. </br>
    </td>
  </tr>
  <tr>
    <td colspan=4>
      <b>Acceptance Criteria:</b> </br>
      Given registered user </br>
      When user enteres his account from another device </br>
      Then give him access to the projects </br>
    </td>
  </tr>
<tr>
    <td>38</td>
    <td>Collaborations</td>
    <td>Default</td>
    <td>4 days</td>
  </tr>
  <tr>
    <td colspan=4 width=500>
      <b>User Story:</b> </br>
      As a registered user, </br>
      I want to collaborate on different projects with my team </br>
      so that speed up development process. </br>
    </td>
  </tr>
  <tr>
    <td colspan=4>
      <b>Acceptance Criteria:</b> </br>
      Given registered user </br>
      When user adds another accounts to the collaboration for specifict project </br>
      Then give that users access to the project </br>
    </td>
  </tr>
<tr>
    <td>39</td>
    <td>Create templates for code structures</td>
    <td>Default</td>
    <td>2 days</td>
  </tr>
  <tr>
    <td colspan=4 width=500>
      <b>User Story:</b> </br>
      As a registered user | programmer, </br>
      I want to extend templates for the code structures </br>
      so that generate code in the best way. </br>
    </td>
  </tr>
  <tr>
    <td colspan=4>
      <b>Acceptance Criteria:</b> </br>
      Given registered user </br>
      When user add template to the code base </br>
      Then save this template for the specific code structure and display it on the creation|edition progress </br>
    </td>
  </tr>
<tr>
    <td>40</td>
    <td>Code structures display</td>
    <td>Default</td>
    <td>2 days</td>
  </tr>
  <tr>
    <td colspan=4 width=500>
      <b>User Story:</b> </br>
      As a registered user, </br>
      I want to view all possible code structures for specific programming language</br>
      so that give a vision of the codding process. </br>
    </td>
  </tr>
  <tr>
    <td colspan=4>
      <b>Acceptance Criteria:</b> </br>
      Given registered/not registered user </br>
      When user opens "Code strucutres" screan </br>
      Then display all code strucutres that are related to specific codding language </br>
    </td>
  </tr>
<tr>
    <td>41</td>
    <td>Change programing language</td>
    <td>Default</td>
    <td>1 day</td>
  </tr>
  <tr>
    <td colspan=4 width=500>
      <b>User Story:</b> </br>
      As a common user, </br>
      I want to change programing language on the code structures page </br>
      so that simplify code generation for different languages. </br>
    </td>
  </tr>
  <tr>
    <td colspan=4>
      <b>Acceptance Criteria:</b> </br>
      Given user </br>
      When user changes programing language on the "code strucuters" screan </br>
      Then update code structures view with proper information for the selected programing language </br>
    </td>
  </tr>
<tr>
    <td>42</td>
    <td>View specific code structure</td>
    <td>Default</td>
    <td>3 days</td>
  </tr>
  <tr>
    <td colspan=4 width=500>
      <b>User Story:</b> </br>
      As a default user, </br>
      I want to view all code structures accessable from the application </br>
      so that simplify development process. </br>
    </td>
  </tr>
  <tr>
    <td colspan=4>
      <b>Acceptance Criteria:</b> </br>
      Given user </br>
      When user clicks on the specific code strucure view </br>
      Then redirect him to the code structure details page </br>
    </td>
  </tr>
<tr>
    <td>43</td>
    <td>Manage code strucures templages</td>
    <td>High</td>
    <td>2 days</td>
  </tr>
  <tr>
    <td colspan=4 width=500>
      <b>User Story:</b> </br>
      As a registered user, </br>
      I want to save default templates for the code strucutres </br>
      so that enshure application will contains default templates anyway. </br>
    </td>
  </tr>
  <tr>
    <td colspan=4>
      <b>Acceptance Criteria:</b> </br>
      Given user try to work with templates </br>
      When user works with default (build-in) templates </br>
      Then synchronize that template with up-to-date version of the application template </br>
    </td>
  </tr>
<tr>
    <td>44</td>
    <td>View all templates</td>
    <td>Priority</td>
    <td>Estimated time</td>
  </tr>
  <tr>
    <td colspan=4 width=500>
      <b>User Story:</b> </br>
      As a registered user, </br>
      I want to view all templates that I created </br>
      so that simplify finding and editing this template if needed. </br>
    </td>
  </tr>
  <tr>
    <td colspan=4>
      <b>Acceptance Criteria:</b> </br>
      Given registered user with provided code strucuters tempaltes </br>
      When user navigates to the "Templates" screan </br>
      Then display all user templates on that page </br>
    </td>
  </tr>
<tr>
    <td>45</td>
    <td>View tempaltes for code structure</td>
    <td>High</td>
    <td>1 day</td>
  </tr>
  <tr>
    <td colspan=4 width=500>
      <b>User Story:</b> </br>
      As a registered user, </br>
      I want to view all templates for the specific code structure </br>
      so that give access to work with templates directly. </br>
    </td>
  </tr>
  <tr>
    <td colspan=4>
      <b>Acceptance Criteria:</b> </br>
      Given any user </br>
      When user selects specific code strcuture and navigates to the templates screan</br>
      Then display all templates for the user that relates to that code strucutre </br>
    </td>
  </tr>
<tr>
    <td>46</td>
    <td>Make all views filterable</td>
    <td>High</td>
    <td>4 days</td>
  </tr>
  <tr>
    <td colspan=4 width=500>
      <b>User Story:</b> </br>
      As a registered user, </br>
      I want to filter different views based on some criteria </br>
      so that simplify searching needed data. </br>
    </td>
  </tr>
  <tr>
    <td colspan=4>
      <b>Acceptance Criteria:</b> </br>
      Given registered user on any data screan </br>
      When user creates criteria </br>
      Then filter all the data based on this criteria </br>
    </td>
  </tr>
<tr>
    <td>47</td>
    <td>Make all view screans sortable</td>
    <td>High</td>
    <td>4 days</td>
  </tr>
  <tr>
    <td colspan=4 width=500>
      <b>User Story:</b> </br>
      As a registered user, </br>
      I want to sort different information of the application </br>
      so that simplify searching information. </br>
    </td>
  </tr>
  <tr>
    <td colspan=4>
      <b>Acceptance Criteria:</b> </br>
      Given registered user on the data view screan </br>
      When user gives sort by and sorting order information </br>
      Then sort all data on that screan </br>
    </td>
  </tr>
<tr>
    <td>48</td>
    <td>Appearence settings</td>
    <td>Low</td>
    <td>1 week</td>
  </tr>
  <tr>
    <td colspan=4 width=500>
      <b>User Story:</b> </br>
      As a registered user, </br>
      I want to change application preferences </br>
      so that edit application for suitable view. </br>
    </td>
  </tr>
  <tr>
    <td colspan=4>
      <b>Acceptance Criteria:</b> </br>
      Given registered user</br>
      When user changes values on the settings screan and saves changes </br>
      Then update view of the application (font settings, displayment settings etc.) </br>
    </td>
  </tr>
<tr>
    <td>49</td>
    <td>Suggestions</td>
    <td>High</td>
    <td>3 days</td>
  </tr>
  <tr>
    <td colspan=4 width=500>
      <b>User Story:</b> </br>
      As a registered user, </br>
      I want to give a suggestion on certain topic</br>
      so that gives a connection with development team to add new features. </br>
    </td>
  </tr>
  <tr>
    <td colspan=4>
      <b>Acceptance Criteria:</b> </br>
      Given registered user </br>
      When user presses "Suggest" button </br>
      Then suggestion form apeares with fields needed for a suggestion and send it to the project manager </br>
    </td>
  </tr>
<tr>
    <td>50</td>
    <td>Report issue</td>
    <td>High</td>
    <td>3 days</td>
  </tr>
  <tr>
    <td colspan=4 width=500>
      <b>User Story:</b> </br>
      As a user|registered user|programmer-user, </br>
      I want to report issue if found one </br>
      so that gives a connection with developer team on bug findings. </br>
    </td>
  </tr>
  <tr>
    <td colspan=4>
      <b>Acceptance Criteria:</b> </br>
      Given any user </br>
      When user founds bug and press "Report issue" </br>
      Then issue form apeares and sends to the lead developer. </br>
    </td>
  </tr>
</tbody>
</table>

</details>
